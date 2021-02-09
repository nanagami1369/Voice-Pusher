using System;
using System.IO;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CoreLibrary.SettingModels
{
    public sealed class SettingsManager : BindableBase, IDisposable
    {
        public SettingsManager()
        {
            Repository = new JsonRepository<Settings>(Config.SettingFileName);
            Watcher = new FileSystemWatcher
            {
                // 親ディレクトリの取得
                Path = Repository.BaseDirctoryPath,

                // ファイル名の設定
                Filter = Repository.FileName,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                InternalBufferSize = 32768
            };
            var changedObservable = Observable
                .FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                    h => (sender, e) => h(e),
                    h => Watcher.Changed += h,
                    h => Watcher.Changed -= h
                );
            var createdObservable = Observable
                .FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                    h => (sender, e) => h(e),
                    h => Watcher.Created += h,
                    h => Watcher.Created -= h
                );
            var fileWatchObservable = changedObservable.Merge(createdObservable
            );
            fileWatchObservable
                .Throttle(TimeSpan.FromMilliseconds(300))
                .Subscribe(OnChangFile)
                .AddTo(Disposable);
            Watcher.AddTo(Disposable);
        }

        private CompositeDisposable Disposable { get; } = new();


        /// <summary>
        ///     現在の設定ファイルの値
        /// </summary>
        public ReactivePropertySlim<Settings> Settings { get; } = new();

        private FileRepository<Settings> Repository { get; }
        private bool IsWatched => Watcher.EnableRaisingEvents;

        private FileSystemWatcher Watcher { get; }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Init(Settings setting)
        {
            Settings.Value = setting;
            StartWatcher();
        }

        private async Task ReadSettingsAsync()
        {
            var setting = await Repository.ReadAsync();
            Settings.Value = setting;
        }

        private async Task WriterSettingsAsync()
        {
            StopWatcher();
            await Repository.WriterAsync(Settings.Value);
            StartWatcher();
        }

        private void StartWatcher()
        {
            if (!IsWatched)
            {
                Watcher.EnableRaisingEvents = true;
            }
        }

        private void StopWatcher()
        {
            if (IsWatched)
            {
                Watcher.EnableRaisingEvents = false;
            }
        }

        private async void OnChangFile(FileSystemEventArgs e)
        {
            try
            {
                await ReadSettingsAsync();
                return;
            }
            catch (JsonReaderException)
            {
            }
            catch (IOException exception)
            {
                if (!exception.Message.Contains("used by another process"))
                {
                    throw;
                }
            }

            await Task.Delay(500);
            // 読み込みエラーの場合は、再挑戦
            try
            {
                await ReadSettingsAsync();
            }
            catch (JsonReaderException)
            {
            }
        }
    }
}

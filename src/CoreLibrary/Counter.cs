using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreLibrary
{
    public sealed class Counter : BindableBase, ICounter
    {
        private int _count = -1;

        public Counter()
        {
            Repository = new JsonRepository<int>(Config.CounterFileName);
            Watcher = new FileSystemWatcher
            {
                // 親ディレクトリの取得
                Path = Repository.BaseDirctoryPath,

                // ファイル名の設定
                Filter = Repository.FileName,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                InternalBufferSize = 32768
            };
            Watcher.Changed += OnChangFile;
            Watcher.Created += OnChangFile;
            Watcher.Deleted += OnChangFile;
            Watcher.Renamed += OnChangFile;
            IncrementCommand = new DelegateCommand(Increment);
        }

        private FileRepository<int> Repository { get; }
        private bool IsWatched => Watcher.EnableRaisingEvents;

        private FileSystemWatcher Watcher { get; }

        public DelegateCommand IncrementCommand { get; }

        //ユーザーが直接値を操作するのでsetterもpublic
        public int Count
        {
            get => _count;
            set
            {
                var inputData = Math.Abs(value);
                WriterCountAsync(inputData).ConfigureAwait(false);
                SetProperty(ref _count, inputData);
            }
        }

        public void Init(int count)
        {
            Count = count;
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Increment()
        {
            if (Count == int.MaxValue)
            {
                Count = 0;
                return;
            }

            Count++;
        }

        private async Task WriterCountAsync(int inputData)
        {
            StopWatcher();
            await Repository.WriterAsync(inputData);
            StartWatcher();
        }

        public void StartWatcher()
        {
            if (!IsWatched)
            {
                Watcher.EnableRaisingEvents = true;
            }
        }

        public void StopWatcher()
        {
            if (IsWatched)
            {
                Watcher.EnableRaisingEvents = false;
            }
        }

        private async void OnChangFile(object sender, FileSystemEventArgs e)
        {
            const int afterSecondDo = 500;
            await Task.Delay(afterSecondDo);
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                case WatcherChangeTypes.Changed:
                    try
                    {
                        _count = await Repository.ReadAsync();
                        RaisePropertyChanged(nameof(Count));
                    }
                    catch (JsonReaderException) { }
                    catch (IOException exception)
                    {
                        if (exception.HResult != -2147024864)
                        {
                            throw;
                        }
                    }

                    await Task.Delay(500);
                    // 読み込みエラーの場合は、再挑戦
                    try
                    {
                        _count = await Repository.ReadAsync();
                        RaisePropertyChanged(nameof(Count));
                    }
                    catch (JsonReaderException) { }

                    break;
                case WatcherChangeTypes.Renamed:
                case WatcherChangeTypes.Deleted:
                case WatcherChangeTypes.All:
                    break;
            }
        }
    }
}

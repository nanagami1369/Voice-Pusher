using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary;
using CommonUILibrary.Models;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class UsedLibraryPresenter : BindableBase, IUsedLibraryPresenter
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private IEnumerable<CopyrightData> _copyrightDatas;
        public IEnumerable<CopyrightData> CopyrightDataList
        {
            get => _copyrightDatas;
            private set => SetProperty(ref _copyrightDatas, value);
        }

        public async Task ReadAsync()
        {

            await SemaphoreSlim.WaitAsync();
            IsEnabled = false;
            try
            {
                await using var stream = new FileStream(Config.UsedLibraryPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream, Config.ApplicationFileEncode);
                var jsonString = await reader.ReadToEndAsync();
                CopyrightDataList = JsonConvert.DeserializeObject<CopyrightData[]>(jsonString);
            }
            finally
            {
                IsEnabled = true;
                SemaphoreSlim.Release();
            }
        }

        public void OpenLicence(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (path.Contains("http"))
                {
                    var psi = new ProcessStartInfo()
                    {
                        FileName = path,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                    return;
                }
                Process.Start(Path.GetFullPath(path));
            }
        }
    }
}

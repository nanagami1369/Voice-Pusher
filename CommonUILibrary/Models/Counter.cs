using System;
using System.IO;
using System.Threading;
using CommonLibrary;
using Prism.Mvvm;

namespace CommonUILibrary.Models
{
    public sealed class Counter : BindableBase, ICounter
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        //ユーザーが直接値を操作するのでsetterもpublic
        private int _count = 0;
        public int Count
        {
            get => _count;
            set
            {
                var inputData = Math.Abs(value);
                writerCountAsync(inputData);
                SetProperty(ref _count, inputData);
            }
        }

        public void Increment()
        {
            Count++;
        }

        private async void writerCountAsync(int count)
        {
            await SemaphoreSlim.WaitAsync();
            try
            {
                await using var stream = new FileStream(Config.CounterFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                await using var writer = new BinaryWriter(stream, Config.ApplicationFileEncode);
                writer.Write(count);
                writer.Flush();
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        public Counter()
        {
            if (!File.Exists(Config.CounterFileName))
            {
                _count = 0;
                return;
            }
            var fileSize = new FileInfo(Config.CounterFileName).Length;
            if (fileSize == 0)
            {
                _count = 0;
                return;
            }
            using var rfs = new FileStream(Config.CounterFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new BinaryReader(rfs, Config.ApplicationFileEncode);
            _count = reader.ReadInt32();
        }
    }
}

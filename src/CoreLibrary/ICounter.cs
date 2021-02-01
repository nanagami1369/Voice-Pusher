using System;
using Prism.Commands;

namespace CoreLibrary
{
    public interface ICounter : IDisposable
    {
        int Count { get; set; }
        DelegateCommand IncrementCommand { get; }
        void Init(int count);
    }
}

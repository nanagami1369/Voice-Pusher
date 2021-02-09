using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace CoreLibrary
{
    public class TextInserter
    {
        public ReactivePropertySlim<bool> Flag { get; set; } = new();

        public ReactivePropertySlim<string> Text { get; } = new();

        public void Insert(string text)
        {
            Text.Value = text;
            Flag.Value = true;
            Flag.Value = false;
        }
    }
}

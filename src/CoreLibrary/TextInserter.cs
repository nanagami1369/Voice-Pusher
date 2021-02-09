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

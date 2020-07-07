using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.MenuModule;
using CoreUILibrary.Moc;
using NUnit.Framework;

namespace CoreUILibrary.Models
{
    [TestFixture()]
    public class CharacterLibraryPresenterTest
    {
        private ICharacterLibraryPresenter Presenter;
        private ICollection<Character> TestLibrary;
        private TestStatusSender TestStatusSender;
        private TestViewSelectable TestViewSelectable;
        private TestMenuContainer TestMenuContainer;

        private MenuItem VoiceEditorMenu => Config.MenuItem[0];
        private MenuItem CharacterEditorMenu => Config.MenuItem[1];

        [SetUp]
        public async Task Setup()
        {
            var gateway = new TestCharacterLibraryGateway();
            TestLibrary = new Collection<Character>()
            {
                new PartialCharacter("霊夢","れいむ"),
                new PartialCharacter("魔理沙","まりさ"),
                new PartialCharacter("舞", "まい"),
                new PartialCharacter("妖夢", "ようむ"),
            };
            gateway.SetDefaultCharacters(TestLibrary);
            TestStatusSender = new TestStatusSender();
            TestViewSelectable = new TestViewSelectable();
            TestMenuContainer = new TestMenuContainer();
            Presenter = new CharacterLibraryPresenter(
                TestStatusSender,
                gateway,
                TestViewSelectable,
                TestMenuContainer);
            await Presenter.LoadCharacterAsync();
            Presenter.ResetView();
        }

        [Test()]
        public void キャラクターを前方一致で検索する()
        {
            Presenter.SearchCharacter("ま");
            Assert.AreEqual(2, Presenter.SelectedLibrary.Count);
        }

        [Test()]
        public void キャラクター名を使い完全一致で検索する()
        {
            Presenter.SearchCharacter("霊夢");
            Assert.AreEqual(1, Presenter.SelectedLibrary.Count);
            StringAssert.AreEqualIgnoringCase("霊夢", Presenter.SelectedLibrary.FirstOrDefault().Name);
        }

        [Test()]
        public void 何も入力していない時はライブラリーをすべて返す()
        {
            Presenter.SearchCharacter("霊夢");
            Presenter.SearchCharacter(null);
            Assert.AreEqual(4, Presenter.SelectedLibrary.Count);
            Assert.That(TestLibrary, Is.EquivalentTo(Presenter.SelectedLibrary));

            StringAssert.AreEqualIgnoringCase("舞", Presenter.SelectedLibrary.FirstOrDefault().Name);
        }

        [Test()]
        public void キャラクターを前方一致で検索しキャラを特定する()
        {
            Presenter.SearchCharacter("まり");
            Assert.AreEqual(1, Presenter.SelectedLibrary.Count);
            StringAssert.AreEqualIgnoringCase("魔理沙", Presenter.SelectedLibrary.FirstOrDefault().Name);
        }

        [Test()]
        public void 読みに存在しない文字で検索する()
        {
            Presenter.SearchCharacter("か");
            Assert.Zero(Presenter.SelectedLibrary.Count);
        }

        [Test()]
        public void ボイスエディタを開く()
        {
            Presenter.SearchWord = "魔理沙";
            Presenter.Index = 1;
            TestMenuContainer.Register(VoiceEditorMenu);
            Presenter.OpenEditorView();
            Assert.That(TestLibrary, Is.EquivalentTo(Presenter.SelectedLibrary));
            StringAssert.AreEqualIgnoringCase("キャラクターが選択されました：魔理沙", TestStatusSender.SentMessage.Message);
            Assert.AreEqual(1, Presenter.Index);
            StringAssert.AreEqualIgnoringCase("", Presenter.SearchWord);
            StringAssert.AreEqualIgnoringCase("Voice", TestViewSelectable.SelectView);
            StringAssert.AreEqualIgnoringCase("魔理沙", TestViewSelectable.SetedCharacter.Name);
        }

        [Test()]
        public void キャラクターを選択していない時にボイスエディタを開こうとする()
        {
            Presenter.SearchWord = "魔理沙あ";
            Presenter.Index = -1;
            Presenter.SelectedLibrary = null;
            TestMenuContainer.Register(VoiceEditorMenu);
            Presenter.OpenEditorView();
            StringAssert.AreEqualIgnoringCase("キャラクターが選択されておりません", TestStatusSender.SentMessage.Message);
            Assert.AreEqual(-1, Presenter.Index);
            StringAssert.AreEqualIgnoringCase("魔理沙あ", Presenter.SearchWord);
            StringAssert.AreEqualIgnoringCase("NotSelectCharacterView", TestViewSelectable.SelectView);
            Assert.IsNull(TestViewSelectable.SetedCharacter);
        }

        [Test()]
        public void キャラクターエディタを開く()
        {
            Presenter.Index = 1;
            TestMenuContainer.Register(CharacterEditorMenu);
            Presenter.OpenEditorView();
            Assert.That(TestLibrary, Is.EquivalentTo(Presenter.SelectedLibrary));
            StringAssert.AreEqualIgnoringCase("キャラクターが選択されました：魔理沙", TestStatusSender.SentMessage.Message);
            Assert.AreEqual(1, Presenter.Index);
            StringAssert.AreEqualIgnoringCase("", Presenter.SearchWord);
            StringAssert.AreEqualIgnoringCase("Character", TestViewSelectable.SelectView);
            StringAssert.AreEqualIgnoringCase("魔理沙", TestViewSelectable.SetedCharacter.Name);
        }

        [Test()]
        public void キャラクターを選択していない時にキャラクターエディタを開こうとする()
        {
            Presenter.SearchWord = "魔理沙あ";
            Presenter.Index = -1;
            Presenter.SelectedLibrary = null;
            TestMenuContainer.Register(CharacterEditorMenu);
            Presenter.OpenEditorView();
            StringAssert.AreEqualIgnoringCase("キャラクターが選択されておりません", TestStatusSender.SentMessage.Message);
            Assert.AreEqual(-1, Presenter.Index);
            StringAssert.AreEqualIgnoringCase("魔理沙あ", Presenter.SearchWord);
            StringAssert.AreEqualIgnoringCase("NotSelectCharacterView", TestViewSelectable.SelectView);
            Assert.IsNull(TestViewSelectable.SetedCharacter);
        }

        [Test()]
        public void 最上行で上キーを押して最下行を選択する()
        {
            var len = TestLibrary.Count;
            Presenter.Index = 0;
            Presenter.UpCharacterLibrary();
            Assert.AreEqual(len - 1, Presenter.Index);
        }

        [Test()]
        public void 最下行で上キーを押して一つ上の行を選択する()
        {
            var len = TestLibrary.Count;
            Presenter.Index = len - 1;
            Presenter.UpCharacterLibrary();
            Assert.AreEqual(len - 2, Presenter.Index);
        }

        [Test()]
        public void 最下行で下キーを押して最上行を選択する()
        {
            var len = TestLibrary.Count;
            Presenter.Index = len - 1;
            Presenter.DownCharacterLibrary();
            Assert.AreEqual(0, Presenter.Index);
        }

        [Test()]
        public void 最上行で下キーを押して一つ下の行を選択する()
        {
            Presenter.Index = 0;
            Presenter.DownCharacterLibrary();
            Assert.AreEqual(1, Presenter.Index);
        }

        [Test()]
        public void インデックスがマイナス１の時０に戻す()
        {
            Presenter.Index = -1;
            Presenter.ResetSelector();
            Assert.Zero(Presenter.Index);
        }
        [Test()]
        public void ライブラリが空の時インデックスを動かさない()
        {
            Presenter.Index = -1;
            Presenter.SelectedLibrary = null;
            Presenter.ResetSelector();
            Assert.AreEqual(-1, Presenter.Index);
            Presenter.Index = -1;
            Presenter.SelectedLibrary = new ObservableCollection<Character>();
            Presenter.ResetSelector();
            Assert.AreEqual(-1, Presenter.Index);
        }

        [Test()]
        public void ライブラリが空の時キー入力を動かさない()
        {
            Presenter.Index = -1;
            Presenter.SelectedLibrary = null;
            Presenter.UpCharacterLibrary();
            Presenter.UpCharacterLibrary();
            Presenter.DownCharacterLibrary();
            Assert.AreEqual(-1, Presenter.Index);
            Presenter.Index = -1;
            Presenter.SelectedLibrary = new ObservableCollection<Character>();
            Presenter.UpCharacterLibrary();
            Presenter.UpCharacterLibrary();
            Presenter.DownCharacterLibrary();
            Assert.AreEqual(-1, Presenter.Index);
        }
    }
}

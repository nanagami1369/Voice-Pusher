using CommonLibrary;
using CommonUILibrary.Models;
using CoreUILibrary.Moc;
using NUnit.Framework;

namespace CoreUILibrary.Models
{
    [TestFixture()]
    public class MenuPresenterTests
    {
        private IMenuPresenter Presenter;
        private TestViewSelectable TestViewSelectable;
        private TestMenuContainer TestMenuContainer;

        [SetUp]
        public void Setup()
        {
            TestViewSelectable = new TestViewSelectable();
            TestMenuContainer = new TestMenuContainer();
            Presenter = new MenuPresenter(TestViewSelectable, TestMenuContainer);
        }

        [Test()]
        public void 初期化時にメニューが最初の値を指しているか()
        {
            Assert.AreEqual(Presenter.SelectedMenu, Presenter.MenuList[0]);
        }

        [Test()]
        public void SelectedMenuの値で画面遷移を行うか()
        {
            Presenter.ChangeView();
            Assert.AreEqual(TestViewSelectable.SelectView, Presenter.MenuList[0].ViewName);
        }

        [Test()]
        public void SelectedMenuが現在のメニューの状態を登録しているか()
        {
            Presenter.ChangeView();
            Assert.AreEqual(TestMenuContainer.Read().Name, Config.MenuItem[0].Name);
        }

        [Test()]
        public void インデックスが範囲外の値の時falseを返すか()
        {
            bool result;
            result = Presenter.TryChangeMenu(-1);
            Assert.False(result);
            result = Presenter.TryChangeMenu(Presenter.MenuList.Length);
            Assert.False(result);
        }

        [Test()]
        public void インデックスが範囲内の値の時Trueを返すか()
        {
            bool result;
            result = Presenter.TryChangeMenu(0);
            Assert.True(result);
            result = Presenter.TryChangeMenu(Presenter.MenuList.Length - 1);
            Assert.True(result);
        }
    }
}

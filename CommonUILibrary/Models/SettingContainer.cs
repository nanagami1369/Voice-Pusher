using CommonLibrary.Modules.SettingModule;
using Unity;

namespace CommonUILibrary.Models
{
    public class SettingContainer : ISettingContainer
    {
        private readonly IUnityContainer _container;

        public void Register(ISetting setting)
        {
            _container.RegisterInstance(setting);
        }

        /// <summary>
        /// 一回以上Register()を呼び出してから呼び出す
        /// </summary>
        public ISetting Read()
        {
            var setting = _container.Resolve<ISetting>();
            return setting.Copy();
        }

        public SettingContainer(IUnityContainer container)
        {
            _container = container;
        }
    }
}

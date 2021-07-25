using DemoWebApi.DataAccess;
using Unity;

namespace DemoWebApi.Config
{
    public static class UnityConfig
    {
        public static IUnityContainer Config()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IProductDA, ProductDA>();

            return container;
        }
    }
}
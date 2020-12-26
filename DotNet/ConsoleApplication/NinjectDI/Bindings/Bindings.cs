using Ninject.Modules;
using NinjectDI.Interfaces;
using NinjectDI.Services;

namespace NinjectDI.Bindings
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMailSender>().To<MockMailSender>();
        }
    }
}

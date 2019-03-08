using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Bootstrapper
{
    public static class BootLoader
    {
        #region Methods
        public static IContainer Init() => Init(new ContainerBuilder());

        public static IContainer Init(ContainerBuilder containerBuilder) => new IoCBuilder(containerBuilder).Container;
        #endregion
    }
}

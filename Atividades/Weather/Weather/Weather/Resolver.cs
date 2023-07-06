using Autofac;
using System.ComponentModel;

namespace Weather
{
    public class Resolver
    {
        private static Autofac.IContainer container;
        public static void Initialize(Autofac.IContainer container)
        {
            Resolver.container = container;
        }
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}

namespace UnitService.DependencyInjection
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Data.Database;
    using Data.Repositories;

    using UnitService.Logic.Directors;
    using UnitService.Logic.Mappers;

    /// <summary>
    /// Providers the IoC resolve method and hosts the container.
    /// </summary>
    public static class TypeLookUp
    {
        /// <summary>
        /// The container instance.
        /// </summary>
        private static IContainer container;

        /// <summary>
        /// Gets the main IoC container.
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (container != null)
                {
                    return container;
                }

                var builder = new ContainerBuilder();
                builder.RegisterType<UnitsRepository>().As<IUnitsRepository>();
                builder.RegisterType<UnitServiceContext>().As<IUnitServiceContext>();
                builder.RegisterType<PersonMapper>().As<IPersonMapper>();
                builder.RegisterType<UnitMapper>().As<IUnitMapper>();
                builder.RegisterType<GetUnitsDirector>().As<IGetUnitsDirector>();
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                container = builder.Build();
                return container;
            }
        }

        /// <summary>
        /// Resolves a bound instance.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
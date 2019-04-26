using Plan360.Application;
using Plan360.Application.Interfaces;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;
using Plan360.Domain.Services;
using Plan360.Infra.Data.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Plan360.UI.MVC.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Plan360.UI.MVC.NinjectWebCommon), "Stop")]

namespace Plan360.UI.MVC
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            //Application Service and Repository Base
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            //Enterprise
            kernel.Bind<IEnterpriseService>().To<EnterpriseService>();
            kernel.Bind<IEnterpriseAppService>().To<EnterpriseAppService>();
            kernel.Bind<IEnterpriseRepository>().To<EnterpriseRepository>();

            //Calendar
            kernel.Bind<ICalendarService>().To<CalendarService>();
            kernel.Bind<ICalendarAppService>().To<CalendarAppService>();
            kernel.Bind<ICalendarRepository>().To<CalendarRepository>();

            //UserProfile
            kernel.Bind<IUserProfileService>().To<UserProfileService>();
            kernel.Bind<IUserProfileAppService>().To<UserProfileAppService>();
            kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();


            //Agent
            kernel.Bind<IAgentService>().To<AgentService>();
            kernel.Bind<IAgentAppService>().To<AgentAppService>();
            kernel.Bind<IAgentRepository>().To<AgentRepository>();



            //Product
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IProductAppService>().To<ProductAppService>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();

            //Brand
            kernel.Bind<IBrandService>().To<BrandService>();
            kernel.Bind<IBrandAppService>().To<BrandAppService>();
            kernel.Bind<IBrandRepository>().To<BrandRepository>();

            //Product Category 
            kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
            kernel.Bind<IProductCategoryAppService>().To<ProductCategoryAppService>();
            kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();





            //SalesForce
            kernel.Bind<ISalesForceService>().To<SalesForceService>();
            kernel.Bind<ISalesForceAppService>().To<SalesForceAppService>();
            kernel.Bind<ISalesForceRepository>().To<SalesForceRepository>();

            //Agent Role
            kernel.Bind<IAgentRoleService>().To<AgentRoleService>();
            kernel.Bind<IAgentRoleAppService>().To<AgentRoleAppService>();
            kernel.Bind<IAgentRoleRepository>().To<AgentRoleRepository>();

            //Entity
            kernel.Bind<IEntityService>().To<EntityService>();
            kernel.Bind<IEntityAppService>().To<EntityAppService>();
            kernel.Bind<IEntityRepository>().To<EntityRepository>();

            //Entity Metadata
            kernel.Bind<IEntityMetadataService>().To<EntityMetadataService>();
            kernel.Bind<IEntityMetadataAppService>().To<EntityMetadataAppService>();
            kernel.Bind<IEntityMetadataRepository>().To<EntityMetadataRepository>();

            //Entity Data
            kernel.Bind<IEntityDataService>().To<EntityDataService>();
            kernel.Bind<IEntityDataAppService>().To<EntityDataAppService>();
            kernel.Bind<IEntityDataRepository>().To<EntityDataRepository>();

            //Entity Record
            kernel.Bind<IEntityRecordService>().To<EntityRecordService>();
            kernel.Bind<IEntityRecordAppService>().To<EntityRecordAppService>();
            kernel.Bind<IEntityRecordRepository>().To<EntityRecordRepository>();

            //Plan
            kernel.Bind<IPlanService>().To<PlanService>();
            kernel.Bind<IPlanAppService>().To<PlanAppService>();
            kernel.Bind<IPlanRepository>().To<PlanRepository>();

            



        }
    }
}

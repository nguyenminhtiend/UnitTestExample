using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    using Autofac.Integration.Mvc;
    using Business.Business;
    using DataAccess.Context;
    using DataAccess.Entities;
    using DataAccess.Repository;
    using System.Data.Entity;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureIoC();
        }
        private static void ConfigureIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<TriangleContext>().As<DbContext>();
            builder.RegisterType<GenericRepositoryImpl<Triangle>>().As<IGenericRepository<Triangle>>();
            builder.RegisterType<TriangleBusinessImpl>().As<ITriangleBusiness>();
            builder.RegisterType<ReportingTriangleImpl>().As<IReportingTriangle>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
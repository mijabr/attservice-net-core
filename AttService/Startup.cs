using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ctree.Data.SqlClient;
using CtreeDataAccess;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using ViewModelProvider.Builders;

namespace AttService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ConnectionSetterFilter));
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);

            var viewModelProviderAssembly = typeof(ProductCodeViewModelBuilder).Assembly;
            builder.RegisterAssemblyTypes(viewModelProviderAssembly).Where(t => t.Name.EndsWith("ViewModelBuilder", StringComparison.Ordinal)).AsSelf().InstancePerLifetimeScope();

            var ctreeDataAccessAssembly = typeof(ProductAndServiceCtreeDataAccess).Assembly;
            builder.RegisterAssemblyTypes(ctreeDataAccessAssembly).Where(t => t.Name.EndsWith("CtreeDataAccess", StringComparison.Ordinal)).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<CtreeSqlConnection>().As<IDbConnection>().InstancePerLifetimeScope();

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("odata", "odata/{database}", AttEdmModel.GetEdmModel(provider));
            });
        }
    }
}

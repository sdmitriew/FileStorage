using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using IoC.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Modulbank.FileStorage.Binders;
using Modulbank.FileStorage.BL.Contracts;
using Modulbank.FileStorage.BL.Core;
using Modulbank.FileStorage.Controllers;
using Modulbank.FileStorage.ExceptionHandling;
using Modulbank.FileStorage.Filters;
using Modulbank.FileStorage.StorageServices.Contracts.Core;
using Swashbuckle.AspNetCore.Swagger;

namespace Modulbank.FileStorage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.ModelBinderProviders.Insert(0, new ProtectedIdModelBinderProvider());
            })
                .AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FileStorage API", Version = "v1" });
            });

           var settings = new AppSettingsModel();
            Configuration.Bind("AppSettings", settings);


            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<CommonModule>();
            containerBuilder.Register(x => settings).As<IStorageServiceConfigs>().SingleInstance();
            containerBuilder.Register(x => settings).As<IBusinessLogicConfigs>().SingleInstance();
            containerBuilder.RegisterType<DownloadController>().PropertiesAutowired();
            containerBuilder.Populate(services);

            ApplicationContainer = containerBuilder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocsPro API V1");

                c.ShowExtensions();
            });

            app.UseMvc();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Remove("Content-Length");
                }
            });

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}

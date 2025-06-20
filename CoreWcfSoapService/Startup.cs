using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Http;
using CoreWCF;
using CoreWCF.Channels;

namespace CoreWcfSoapService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices();
            services.AddServiceModelMetadata();

            // OrderService'i DI container'a ekle
            services.AddTransient<OrderService>();

            // Synchronous IO gerekli
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseServiceModel(builder =>
            {
                // Service'i ekle
                builder.AddService<OrderService>();

                // BasicHttpBinding endpoint
                builder.AddServiceEndpoint<OrderService, IOrderService>(
                    new BasicHttpBinding(BasicHttpSecurityMode.None),
                    "/OrderService.svc");

                // Service metadata behavior
                var serviceMetadataBehavior = app.ApplicationServices.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
                serviceMetadataBehavior.HttpGetEnabled = true;
                serviceMetadataBehavior.HttpGetUrl = new System.Uri("http://localhost:5005/OrderService.svc");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("CoreWCF Service is running...");
                });
            });
        }
    }
}
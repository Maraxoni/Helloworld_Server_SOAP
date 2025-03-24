using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Helloworld_Server_SOAP
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:8080")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddServiceModelServices();
            services.AddServiceModelMetadata();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<HelloWorldService>();
                serviceBuilder.AddServiceEndpoint<HelloWorldService, IHelloWorld>(
                    new BasicHttpBinding(), "/HelloWorldService");
            });

            var serviceMetadata = app.ApplicationServices.GetRequiredService<ServiceMetadataBehavior>();
            serviceMetadata.HttpGetEnabled = true;
        }
    }
}

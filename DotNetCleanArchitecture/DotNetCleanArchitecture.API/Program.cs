using Customers.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetCleanArchitecture.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config)=>
                {
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env.EnvironmentName}.json");
                    config.AddEnvironmentVariables();

                    // add different env parameters
                    if(! env.IsDevelopment())
                    {

                    }
                    else
                    {
                        // config.AddUserSecrets(Assembly.Load(new AssemblyName(env.ApplicationName)));
                    }
                })
                .ConfigureLogging((hostingContext, logging)=>
                {
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options => 
                    {
                        // Http
                        options.Listen(IPAddress.Any, 80, listenOptions =>
                        {
                            listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
                        });
                    });
                    webBuilder.UseStartup<Startup>().UseDefaultServiceProvider(options => options.ValidateScopes = false);
                });
    }
}

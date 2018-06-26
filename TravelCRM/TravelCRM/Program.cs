using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TravelCRMRepo;
using Microsoft.Extensions.DependencyInjection;
using TravelCRMData;

namespace TravelCRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureLogging(builder => builder.AddFile(options => {
                 options.FileName = "diagnostics-"; // The log file prefixes
                 options.LogDirectory = "LogFiles"; // The directory to write the logs
                 options.FileSizeLimit = 20 * 1024 * 1024; // The maximum log file size (20MB here)
             }))
                .UseStartup<Startup>()
                .Build();
    }
}

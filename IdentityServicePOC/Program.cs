using IdentityService.Infrastructure.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace IdentityServicePOC
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostBuilderContext, logging) =>
            {
                logging.AddTheCodeFileLogger(options =>
                {
                    hostBuilderContext.Configuration.GetSection("Logging").GetSection("FileLogger").GetSection("fileLogDetailsEntity").Bind(options);
                });
            })
            .UseStartup<Startup>();
    }
}

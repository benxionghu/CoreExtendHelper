using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

using NetCoreCustomConfig.Common;

namespace NetCoreCustomConfig
{
    /// <summary>
    /// 自定义获取配置项   老肖的极客时间教程
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureHostConfiguration(configure =>
                {
                    //使用
                    configure.AddMyConfiguration();
                    var config = configure.Build();

                    ChangeToken.OnChange(() => config.GetReloadToken(), () =>
                     {
                         Console.WriteLine(config["lastTime"]);
                     });
                    //自定义配置框架配置
                    Console.WriteLine("开始了");
                })
            ;
    }
}

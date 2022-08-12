using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;

namespace API.DemoSolutions
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
       .Build();

        public static void Main(string[] args)
        {
            string connectionString = Configuration.GetConnectionString("DemoSeriLogDB");
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
               {
                   new SqlColumn("UserName", SqlDbType.NVarChar)
                 }
            };

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "Log" }
                , null, null, LogEventLevel.Information, null, columnOptions: columnOptions, null, null)
                .WriteTo.Debug(new RenderedCompactJsonFormatter())
                .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)//To capture Information and error only
                //.MinimumLevel.Information()
                .CreateLogger();
            try
            {
                Log.Information("starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host Terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();//serilog;;
    }
}

using Fetch_top_200_stories_API.Utilities.Interfaces;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Fetch_top_200_stories_API.Utilities
{
    public class ExceptionLogger : ISerilogLogger
    {
        public ExceptionLogger()
        {
            var tableName = Startup.LogTableName;
            var con = Startup.Connectionstring;

            switch (Startup.WebApiLogLevel.ToUpper())
            {
                case "DEBUG":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()                        
                       // .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
                case "ERROR":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Error()                       
                        //.WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
                case "VERBOSE":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()                       
                        //.WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;

                case "FATAL":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Fatal()
                       // .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;

                default:
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        //.WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
            }
        }
        public ExceptionLogger(string domainId)
        {
            var tableName = Startup.LogTableName;
            var con = Startup.Connectionstring;

            switch (Startup.WebApiLogLevel.ToUpper())
            {
                case "DEBUG":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
                case "ERROR":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Error()
                        .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
                case "VERBOSE":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;

                case "FATAL":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Fatal()
                        .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;

                default:
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
            }
        }

        public void APILogger()
        {
            var tableName = Startup.LogTableName;
            var con = Startup.Connectionstring;

            switch (Startup.WebApiLogLevel.ToUpper())
            {
                case "DEBUG":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                      
                        //.WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
                case "ERROR":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Error()
                       // .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
                case "VERBOSE":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                       // .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;

                case "FATAL":
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Fatal()
                       // .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;

                default:
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                       // .WriteTo.MSSqlServer(con, tableName, columnOptions: new ColumnOptions())
                        .WriteTo.File("./Logs/log.txt", buffered: true, rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                        .CreateLogger();
                    break;
            }
        }
    }
}

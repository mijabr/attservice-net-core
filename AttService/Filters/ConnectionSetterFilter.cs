using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;

namespace AttService
{
    internal class ConnectionSetterFilter : IActionFilter
    {
        IDbConnection connection;
        public ConnectionSetterFilter(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var segments = context.HttpContext.Request.Path.ToString().Split('/');
            if (segments.Length > 2 && segments[1] == "odata")
            {
                var databaseName = segments[2];
                var appDatabaseHost = "localhost";
                var appDatabasePort = 6597;
                var appMaxPoolSize = 5;
                var appConnectionLifetime = 1;
                var appConnectionTimeout = 15;
                connection.ConnectionString = $"uid=admin;pwd=7d2kRU;database={databaseName};host={appDatabaseHost};port={appDatabasePort};maxpoolsize={appMaxPoolSize};connectionlifetime={appConnectionLifetime};connectiontimeout={appConnectionTimeout};";
            }
        }
    }
}

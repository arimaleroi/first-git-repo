using Microsoft.AspNetCore.Mvc.Filters;

namespace HW_6_1_Chernysh.Core.Filters
{
    public class LoggerFilter : IAsyncActionFilter
    {
        private readonly ILogger<LoggerFilter> _logger;

        public LoggerFilter(ILogger<LoggerFilter> logger)
        {
            _logger = logger;

        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.Log(LogLevel.Information, $"Request {context.ActionDescriptor} log message.");

            ActionExecutedContext actionResponseContext = await next();

            _logger.Log(LogLevel.Information, $"Response {actionResponseContext.ActionDescriptor} log message");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HW_6_1_Chernysh.Core.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogDebug($"Exception Filter - Message: {context.Exception.Message}");

            switch (context.Exception)
            {
                case InvalidOperationException ex:
                    context.Result = new StatusCodeResult(501);
                    _logger.LogDebug($"InvalidOperationException is handled.");
                    break;
                    default: break;
            }
            return Task.CompletedTask;
        }
    }
}

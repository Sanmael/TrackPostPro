using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Filters
{
    public class LogExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILoggerService _loggerService;
        public LogExceptionFilter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public async Task OnExceptionAsync(ExceptionContext context)
        {                        
            await _loggerService.SaveLog(context.Exception, context.Exception.Message, context.ActionDescriptor.DisplayName);

            string errorMessage = ErrorMessage.InternalServerErrorMessage;        

            context.Result = new ObjectResult(errorMessage)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            
            context.ExceptionHandled = true;
        }
    }
}

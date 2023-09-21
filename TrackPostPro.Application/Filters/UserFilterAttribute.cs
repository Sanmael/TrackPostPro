//using DomainTrackPostPro;
//using DomainTrackPostPro.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace TrackPostPro.Application.Filters
//{
//    public class UserFilterAttribute : ActionFilterAttribute
//    {
//        private readonly UserFilterService _userFilterService;

//        public UserFilterAttribute(UserFilterService userFilterService)
//        {
//            _userFilterService = userFilterService;
//        }

//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            string userId = context.HttpContext.Request.Query["Username"];
//            string pass = context.HttpContext.Request.Query["Password"];
//            context.ActionArguments["Username"] = userId;
//            context.ActionArguments["Password"] = pass;

//            //Guid.TryParse(userId, out Guid teste);
//            //if (teste == Guid.Empty || !_userFilterService.ValidateCredentialsAsync(userId, pass).Result)
//            //{
//            //    context.Result = new ObjectResult("Credenciais inválidas")
//            //    {
//            //        StatusCode = 401
//            //    };
                 
//            //    return;
//            //}

//            base.OnActionExecuting(context);
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc.Filters;


namespace UnifyResponse.Filter
{
    /// <summary>
    /// 执行方法   执行操作日志、参数验证，权限控制、方法做缓存
    /// </summary>
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            System.Console.WriteLine("在方法执行之后做一些事情");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Console.WriteLine("在方法执行之前做一些事情");
        }
    }
}

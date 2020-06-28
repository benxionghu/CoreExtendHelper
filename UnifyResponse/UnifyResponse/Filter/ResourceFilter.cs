using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Filter
{
    /// <summary>
    /// 资源过滤器 资源缓存、防盗链
    /// </summary>
    public class ResourceFilter : Attribute, IResourceFilter
    {
        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine(context.HttpContext.Response.StatusCode);
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var httpContext = context.HttpContext;
            //输出当前请求方法
            Console.WriteLine(httpContext.Request.Method);
        }
    }
}

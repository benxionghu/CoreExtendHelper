using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UnifyResponse.Middlewar.Model;

namespace UnifyResponse.Middlewar
{
    /// <summary>
    /// 自带参数的中间件
    /// </summary>
    public class AutomaticParamMiddleware : MiddlewareModel
    {
        private readonly RequestDelegate _next;
        private double X, Y;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public AutomaticParamMiddleware(RequestDelegate next, double x, double y)
        {
            _next = next;
            X = x;
            Y = y;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var result = X + Y;
            context.Response.Headers["Compute-Result"] = $"{X} + {Y} = {result}";
            await _next(context);
        }

    }
}
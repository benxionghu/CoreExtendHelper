using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UnifyResponse.LogHelper;

namespace UnifyResponse.Unitl
{
    /// <summary>
    /// 请求参数日志中间件
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await FormatRequest(context.Request);
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        /// <summary>
        /// 请求参数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<string> FormatRequest(HttpRequest request)
        {
            try
            {
                var body = request.Body;
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body = body;
                ExceptionLessLog.Error($"请求参数为：{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}");
                return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
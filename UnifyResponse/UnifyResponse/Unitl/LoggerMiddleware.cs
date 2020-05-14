using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UnifyResponse.LogHelper;

namespace UnifyResponse.Unitl
{
    /// <summary>
    /// https://www.cnblogs.com/lwqlun/p/10954936.html
    /// </summary>
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            var url = $@"{context.Request.Scheme} {context.Request.Host}{context.Request.Path}";
            var stream = context.Request.Body;
            if (context.Request.Method.ToLower().Contains("get"))
            {
                ExceptionLessLog.Info($"当前请求为Get请求,url为：{url},请求参数为:{context.Request.QueryString}");
            }
            var length = context.Request?.ContentLength;
            if (length != null && length > 0)
            {
                var streamReader = new StreamReader(stream, Encoding.UTF8);
                var postJson = await streamReader.ReadToEndAsync();
                ExceptionLessLog.Info($"当前请求为Post请求,url为：{url},请求参数为:{postJson}");
            }
            context.Request.Body.Position = 0;

            var originalResponseStream = context.Response.Body;
            using (var ms = new MemoryStream())
            {
                context.Response.Body = ms;
                await _next(context);
                ms.Position = 0;
                var responseReader = new StreamReader(ms);
                var responseContent = responseReader.ReadToEnd();
                ExceptionLessLog.Info($"请求url为：{url} 状态为:{context.Response.StatusCode} 返回参数为{responseContent}");
                ms.Position = 0;
                await ms.CopyToAsync(originalResponseStream);
                context.Response.Body = originalResponseStream;
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            try
            {
                var body = request.Body;
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body = body;
                ExceptionLessLog.Info($"请求参数为：{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}");
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
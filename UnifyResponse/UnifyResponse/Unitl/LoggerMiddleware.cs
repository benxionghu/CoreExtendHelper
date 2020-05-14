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
          
            using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8))
            {
                var body = context.Request.Body;
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body = body;
            }
            using (var ms = new MemoryStream())
            {
                context.Response.Body = ms;
                await _next(context);
                context.Response.Body.Position = 0;
                var responseReader = new StreamReader(context.Response.Body);
                var responseContent = responseReader.ReadToEnd();
                Console.WriteLine($"Response Body: {responseContent}");
                context.Response.Body.Position = 0;
            }

            //await FormatRequest(context.Request);
            //var originalResponseStream = context.Response.Body;
            //using (var ms = new MemoryStream())
            //{
            //    context.Response.Body = ms;
            //    await _next(context);
            //    ms.Position = 0;
            //    var responseReader = new StreamReader(ms);
            //    var responseContent = responseReader.ReadToEnd();
            //    Console.WriteLine($"Response Body: {responseContent} response.StatusCode{context.Response.StatusCode}");
            //    ms.Position = 0;
            //    await ms.CopyToAsync(originalResponseStream);
            //    context.Response.Body = originalResponseStream;
            //}
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
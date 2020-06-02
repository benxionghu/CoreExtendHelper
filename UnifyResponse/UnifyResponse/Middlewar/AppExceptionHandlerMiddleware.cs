using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UnifyResponse.Common;
using UnifyResponse.LogHelper;

namespace UnifyResponse.Middlewar
{
    /// <summary>
    /// 全局异常类
    /// </summary>
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public AppExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {

            //返回友好的提示
            var response = context.Response;

            //状态码
            if (exception is UnauthorizedAccessException)
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (exception != null)
                response.StatusCode = (int)HttpStatusCode.BadRequest;

            response.ContentType = context.Request.Headers["Accept"];

            if (response.ContentType.ToLower() == "application/xml")
            {
                var result = new ResponseErrorResult<object>
                {
                    ErrorCode = -9999,
                    ErrorMessage = exception.GetBaseException().Message,
                };
                ExceptionLessLog.Error($@"错误原因为:{exception.GetBaseException().Message},错误详细为:{exception.GetBaseException().ToString()}");
                await response.WriteAsync(Object2XmlString(result)).ConfigureAwait(false);
            }
            else
            {
                response.ContentType = "application/json";
                var result = new ResponseErrorResult<object>
                {
                    ErrorCode = -9999,
                    ErrorMessage = exception.GetBaseException().Message,
                };
                ExceptionLessLog.Error($@"错误原因为:{exception.GetBaseException().Message},错误详细为:{exception.GetBaseException().ToString()}");
                await response.WriteAsync(JsonConvert.SerializeObject(result)).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 对象转为Xml
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static string Object2XmlString(object o)
        {
            var sw = new StringWriter();
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                serializer.Serialize(sw, o);
            }
            catch
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Dispose();
            }
            return sw.ToString();
        }
    }
}

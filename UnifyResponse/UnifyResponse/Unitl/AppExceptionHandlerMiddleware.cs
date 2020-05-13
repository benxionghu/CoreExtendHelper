using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnifyResponse.Common;
using UnifyResponse.LogHelper;

namespace UnifyResponse.Unitl
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public AppExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

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
            else if (exception is Exception)
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

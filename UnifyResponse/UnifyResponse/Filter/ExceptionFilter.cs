using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

using UnifyResponse.Common;
using UnifyResponse.LogHelper;

namespace UnifyResponse.Filter
{
    /// <summary>
    /// 异常过滤器  暂时只能记日志
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            ExceptionLessLog.Error($@"错误原因为:{exception.GetBaseException().Message},错误详细为:{exception.GetBaseException().ToString()}");
            //var exception = filterContext.Exception;
            //var context = filterContext.HttpContext;
            //var response = context.Response;
            //if (exception is UnauthorizedAccessException)
            //    response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //else if (exception != null)
            //    response.StatusCode = (int)HttpStatusCode.BadRequest;
            //response.ContentType = context.Request.Headers["Accept"];
            //if (response.ContentType.ToLower() == "application/xml")
            //{
            //    var result = new ResponseErrorResult<object>
            //    {
            //        ErrorCode = -9999,
            //        ErrorMessage = exception.GetBaseException().Message,
            //    };
            //    ExceptionLessLog.Error($@"错误原因为:{exception.GetBaseException().Message},错误详细为:{exception.GetBaseException().ToString()}");
            //    response.WriteAsync(Object2XmlString(result)).ConfigureAwait(true);
            //}
            //else
            //{
            //    response.ContentType = "application/json";
            //    var result = new ResponseErrorResult<object>
            //    {
            //        ErrorCode = -9999,
            //        ErrorMessage = exception.GetBaseException().Message,
            //    };
            //    ExceptionLessLog.Error($@"错误原因为:{exception.GetBaseException().Message},错误详细为:{exception.GetBaseException().ToString()}");
            //    response.WriteAsync(JsonConvert.SerializeObject(result)).ConfigureAwait(true);
            //}
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

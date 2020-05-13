using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifyResponse.Unitl
{
    public class InputOutputAlterMiddleware
    {
        private readonly RequestDelegate _next;

        public InputOutputAlterMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            //判断是POST提交过来的
            if (method.Equals("POST"))
            {
                var body = context.Request.Body;
                var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
                context.Request.Body = body;

                using (var ms = new MemoryStream())
                {
                    var orgBodyStream = context.Response.Body;
                    context.Response.Body = ms;
                    context.Response.ContentType = "application/json";
                    await _next(context);

                    using (var sr = new StreamReader(ms))
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        //得到Action的返回值
                        var responseJsonResult = sr.ReadToEnd();
                        ms.Seek(0, SeekOrigin.Begin);
                        //如下代码若不注释则会显示Action的返回值 这里做了注释 则清空Action传过来的值  
                        //  await ms.CopyToAsync(orgBodyStream);

                        context.Response.Body = orgBodyStream;
                        //显示修改后的数据 
                        await context.Response.WriteAsync(responseJsonResult, Encoding.UTF8);
                    }
                }
            }
        }


    }
}

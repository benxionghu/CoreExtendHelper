using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnifyResponse.Unitl
{
    /// <summary>
    /// 
    /// </summary>
    public static class InputOutputAlterMiddlewareExtensions
    {
        public static IApplicationBuilder UseInputOutputAlter(
         this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InputOutputAlterMiddleware>();
        }
    }
}

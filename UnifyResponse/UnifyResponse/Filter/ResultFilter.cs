using Microsoft.AspNetCore.Mvc.Filters;

namespace UnifyResponse.Filter
{
    /// <summary>
    /// 执行结果   格式化返回数据 
    /// </summary>
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            System.Console.WriteLine("在结果执行之后调用的操作...");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            System.Console.WriteLine("在结果执行之前调用的一系列操作");
        }
    }
}

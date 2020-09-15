using Castle.DynamicProxy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aop.Service
{
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($@"Invocation before,Method:{invocation.Method.Name}");
            //具体方法执行
            invocation.Proceed();
            Console.WriteLine($@"Invocation after,Method:{invocation.Method.Name}");
        }
    }
}

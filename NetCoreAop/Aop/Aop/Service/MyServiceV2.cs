using Aop.IService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aop.Service
{
    public class MyServiceV2 : IMyService
    {
        public MyNameService NameService { get; set; }
        public async Task ShowCode()
        {
            await Task.Run(() =>
            {
                System.Console.WriteLine($@"MyServiceV2.ShowCode:{ GetHashCode()},NameService是否为空:{NameService == null}");
            });
        }
    }

    public class MyNameService
    {
    }
}

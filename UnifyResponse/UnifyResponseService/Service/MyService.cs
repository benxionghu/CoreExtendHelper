using System;
using System.Collections.Generic;
using System.Text;
using UnifyResponseService.IService;

namespace UnifyResponseService.Service
{
    public class MyService : IMyService
    {
        public void Test()
        {
            Console.WriteLine("当前为测试方法");
        }
    }
}

using System;

namespace ClassUpdateLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstEntity = new Entity()
            {

                Id = Guid.NewGuid(),
                OId = DateTime.Now.ToString("yyyyMMddHHmmss"),
                A = "a1",
                B = 0.01,
                C = true,
            };
            var lastEntity = new Entity()
            {
                A = "a2",
                B = 0.02,
                C = true
            };
            //记录修改的字段
            var logs = firstEntity.GetPropertyLogs(lastEntity);
            Console.ReadKey();
        }
    }
}

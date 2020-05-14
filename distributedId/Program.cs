using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace distributedId
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ids = new List<long>();
            //var woodwork = new SnowflakeId(15, 3);
            //for (var i = 0; i < 100; i++)
            //{
            //    var idTest = woodwork.NextId();
            //    ids.Add(idTest);
            //}
            //foreach (var id in ids)
            //{
            //    var idStr = SnowflakeId.AnalyzeId(id);
            //    Console.WriteLine("雪花ID：" + id + "\t\b解析-> " + idStr);
            //}
            var hashTable = new Hashtable();
            var woodwork = new SnowflakeId(20, 3);
            Parallel.For(1, 100, x =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00"));
                for (var i = 0; i < 10000; i++)
                {
                    var idTest = woodwork.NextId();
                    hashTable.Add(idTest, idTest);
                }
            });
            Console.WriteLine(hashTable.Count);
            Console.ReadKey();
        }
    }
}

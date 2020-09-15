using Aop.IService;

using System.Threading.Tasks;

namespace Aop.Service
{
    public class MyService : IMyService
    {
        public async Task ShowCode()
        {
            await Task.Run(() =>
            {
                System.Console.WriteLine($@"MyService.ShowCode:{ GetHashCode()}");
            });
        }
    }
}

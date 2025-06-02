using System.Threading.Tasks;

namespace Services
{
    public class PurchasesService : IService
    {
        public Task InitializeAsync()
        {
           return Task.Delay(1000);
        }
    }
}
using System.Threading.Tasks;

namespace Services
{
    public class AdsService : IService
    {
        public Task InitializeAsync()
        {
            return Task.Delay(2000);
        }
    }
}
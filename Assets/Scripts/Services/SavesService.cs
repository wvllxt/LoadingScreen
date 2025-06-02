using System.Threading.Tasks;

namespace Services
{
    public class SavesService : IService
    {
        public Task InitializeAsync()
        {
            return Task.Delay(2000);
        }
    }
}
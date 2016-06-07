using System.Threading.Tasks;

namespace demo.di
{
    public class MailNotificationService : INotificationService
    {
        public async Task NotifyUser(string email, string message)
        {
            // implementation
        }
    }
}
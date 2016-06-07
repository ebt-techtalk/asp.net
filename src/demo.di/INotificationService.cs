using System.Threading.Tasks;

namespace demo.di
{
    public interface INotificationService
    {
        Task NotifyUser(string email, string message);
    }
}
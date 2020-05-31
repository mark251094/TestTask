using TestTask.Common.Models;

namespace TestTask.Services
{
    public interface ILogService
    {
        void Create(string action, string details = null);
        LogListViewModel GetAll();
    }
}

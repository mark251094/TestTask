using Microsoft.Extensions.Logging;
using TestTask.Common.Models;
using TestTask.DataAccess.Entities;
using TestTask.DataAccess.UnitOfWork;

namespace TestTask.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LogService> _logger;

        public LogService(IUnitOfWork unitOfWork, ILogger<LogService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void Create(string action, string details = null)
        {
            var log = new Log
            {
                Action = action,
                Details = details

            };

            _unitOfWork.Logs.Create(log);

            _unitOfWork.Save();
        }

        public LogListViewModel GetAll()
        {
            var logs = _unitOfWork.Logs.GetAll();

            return new LogListViewModel { Logs = logs };
        }

    }
}

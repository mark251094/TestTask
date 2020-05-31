using System.Collections.Generic;
using TestTask.DataAccess.Entities;

namespace TestTask.Common.Models
{
    public class LogListViewModel
    {
        public IEnumerable<Log> Logs { get; set; }
    }
}

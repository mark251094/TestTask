using System.Collections.Generic;
using TestTask.DataAccess.Entities;

namespace TestTask.Common.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}

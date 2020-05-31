using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.DataAccess.Entities
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public string Action { get; set; }

        public string Details { get; set; }

    }
}

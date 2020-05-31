using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.DataAccess.Entities
{
    [Table("Users")]
    public class User : ICloneable
    {
        [Key]
        public int Id { get; set; }
   
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

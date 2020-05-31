using System.ComponentModel.DataAnnotations;

namespace TestTask.Common.Models
{
    public class UserUpdateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [StringLength(8, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        [StringLength(20, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is incorect.")]
        public string Email { get; set; }
    }
}

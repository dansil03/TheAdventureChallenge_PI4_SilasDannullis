using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace core1.Models
{
    public class User
    {
        [Key, DisplayName("User Name"), StringLength(100)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

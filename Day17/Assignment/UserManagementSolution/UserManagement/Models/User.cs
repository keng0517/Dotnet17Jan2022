using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int user_id { get; set; }

        [Display(Name = "Username")]
        public string user_name { get; set; }

        [Display(Name = "Password")]
        public string user_password { get; set; }

        [Display(Name = "Email Address")]
        public string user_email { get; set; }

        
    }
}

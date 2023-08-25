using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models.DTOs.AuthDTO
{
    public class UserLoginDTO
    {
        [Required]
        public string userId { get; set; } = string.Empty;
        [Required]
        public string userUserName { get; set; }
        [Required]
        public string password { get; set; }
    }
}

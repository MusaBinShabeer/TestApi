using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models.DTOs.AuthDTO
{
    public class UserLoginDTO
    {
        [Required]
        public string userUserName { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
    public class ForgotPasswordDTO
    {
        [Required]
        public string userEmailAddress { get; set; } = string.Empty;
    }
}

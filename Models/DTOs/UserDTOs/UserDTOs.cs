using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models.DTOs.UserDTOs
{
    public class UserResponseDTO
    {
        public string userId { get; set; } = string.Empty;
        public string userUserName { get; set; } = string.Empty;
        public string userFirstName { get; set; } = string.Empty;
        public string userLastName { get; set; } = string.Empty;
        public string userEmailAddress { get; set; } = string.Empty;
        public string userPhoneNo { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string userToken { get; set; } = string.Empty;
        public bool is_active { get; set; } = true;
        public string fkUserType { get; set; } = string.Empty;
    }
    public class AddUserDTO
    {
        [Required]
        public string userUserName { get; set; } = string.Empty;
        public string userFirstName { get; set; } = string.Empty;
        public string userLastName { get; set; } = string.Empty;
        [Required]
        public string userEmailAddress { get; set; } = string.Empty;
        public string userPhoneNo { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        [Required]
        public string fkUserType { get; set; } = string.Empty;
    }
    public class UpdateUserDTO
    {
        [Required]
        public string userId { get; set; } = string.Empty;
        public string userUserName { get; set; } = string.Empty;
        public string userFirstName { get; set; } = string.Empty;
        public string userLastName { get; set; } = string.Empty;
        public string userEmailAddress { get; set; } = string.Empty;
        public string userPhoneNo { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public string fkUserType { get; set; } = string.Empty;
    }
}

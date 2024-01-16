using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.DTOs.UserDTOs
{
    public class UserDTO 
    {
        public string userGender { get; set; } = string.Empty;
        public string userPhoneNo { get; set; } = string.Empty;
        public string userClick { get; set; } = string.Empty;
    }
    public class UserResponseDTO :UserDTO
    {
        public string userId { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
    }
    public class AddUserDTO: UserDTO
    {
        [Required]
        public string userName { get; set; } = string.Empty;
       
    }
    public class UpdateUserDTO :UserDTO
    {
        [Required]
        public string userId { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
    }
    public class UserTestDTO
    {
        public string userGender { get; set; } = "Male";
        public string userPhoneNo { get; set; } = "03455990367";
        public string userClick { get; set; } ="yes";
    }
    public class AddUserTestDTO : UserDTO
    {
        [Required]
        public string userName { get; set; } = "Musa";

    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models.DTOs.UserTypeDTOs
{
    public class UserTypeResponseDTO
    {
        public string typeId { get; set; } = string.Empty;
        public string typeName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public List<Guid> users { get; set; }
    }
    public class AddUserTypeDTO

    {
        [Required]
        public string typeName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
       
    }
    public class UpdateUserTypeDTO
    {
        [Required]
        public string typeId { get; set; } = string.Empty;
        public string typeName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public string users { get; set; } = string.Empty;
    }

}

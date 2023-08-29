using AutoMapper;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;

namespace UserManagementApi.Repositories.UserServicesRepo
{
    public interface IUserService
    {
        public  Task<ResponseModel<UserResponseDTO>> AddUser(AddUserDTO requestDto);
        public  Task<ResponseModel<UserResponseDTO>> UpdateUser(UpdateUserDTO requestDto);
        public  Task<ResponseModel<UserResponseDTO>> GetUserById(string userID);
        public  Task<ResponseModel<List<UserResponseDTO>>> GetAllUsers();
        public  Task<ResponseModel> DeleteUserById(string userId);
    }
}

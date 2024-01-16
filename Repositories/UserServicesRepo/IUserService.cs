using AutoMapper;
using TestApi.Models.DTOs.ResponseDTO;
using TestApi.Models.DTOs.UserDTOs;
using TestApi.Models.DBModels.DBTables;

namespace TestApi.Repositories.UserServicesRepo
{
    public interface IUserService
    {
        public Task<ResponseModel<UserResponseDTO>> AddUser(AddUserDTO requestDto);
        public Task<ResponseModel<UserResponseDTO>> UpdateUser(UpdateUserDTO requestDto);
        public Task<ResponseModel<UserResponseDTO>> GetUserById(string userID);
        public Task<ResponseModel<List<UserResponseDTO>>> GetAllUsers();
        public Task<ResponseModel> DeleteUserById(string userId);
    }
}

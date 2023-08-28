using AutoMapper;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.AuthDTO;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;

namespace UserManagementApi.Repositories.AuthServicesRepo
{
    public interface IAuthServices
    {
        public Task<ResponseModel> AuthUser(UserLoginDTO requestDto);

        public Task<ResponseModel> ForgotPassword(ForgotPasswordDTO requestDto);


    }
}

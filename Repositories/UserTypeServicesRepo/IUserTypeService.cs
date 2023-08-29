using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserTypeDTOs;

namespace UserManagementApi.Repositories.UserTypeServicesRepo
{
    public interface IUserTypeService
    {
        public Task<ResponseModel<List<UserTypeResponseDTO>>> GetUserType();
        public Task<ResponseModel<UserTypeResponseDTO>> GetUserTypeById(string typeId);
        public Task<ResponseModel<UserTypeResponseDTO>> AddUserType(AddUserTypeDTO requestDto);

        public Task<ResponseModel<UserTypeResponseDTO>> UpdateUserType(UpdateUserTypeDTO requestDto);
        public Task<ResponseModel<UserTypeResponseDTO>> DeleteById(string typeId);

    }
}

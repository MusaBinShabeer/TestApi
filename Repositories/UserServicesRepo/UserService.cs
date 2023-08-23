using AutoMapper;
using UserManagementApi.Models.DBModels;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;

namespace UserManagementApi.Repositories.UserServicesRepo
{
    public class UserService : IUserService
    {
        private readonly DBManagementContext db;
        private readonly IMapper mapper; 
        public UserService(DBManagementContext db, IMapper mapper)
        { 
            this.db = db; 
            this.mapper = mapper;
        }
        public async Task<ResponseModel<UserResponseDTO>> AddUser(AddUserDTO requestDto)
        {
            try
            {
                var newUser = new tbl_user();
                newUser = mapper.Map<tbl_user>(requestDto);
                await db.AddAsync(newUser);
                await db.SaveChangesAsync();
                return new ResponseModel<UserResponseDTO>()
                {
                    data = mapper.Map<UserResponseDTO>(newUser),
                    remarks = "Success",
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserResponseDTO>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }

        }
        public async Task<ResponseModel<UserResponseDTO>> UpdateUser(UpdateUserDTO requestDto)
        {
            try
            {
                var existingUser = await db.FindAsync<tbl_user>(requestDto.userId);
                existingUser = mapper.Map<tbl_user>(requestDto);
                if (existingUser == null)
                {
                    return new ResponseModel<UserResponseDTO>()
                    {
                        remarks = "User not found",
                        success = false,
                    };
                }
                mapper.Map(requestDto, existingUser);
                await db.SaveChangesAsync();

                return new ResponseModel<UserResponseDTO>()
                {
                    data = mapper.Map<UserResponseDTO>(existingUser),
                    remarks = "Success",
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserResponseDTO>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
    }
}

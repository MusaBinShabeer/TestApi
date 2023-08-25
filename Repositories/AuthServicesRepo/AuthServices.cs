using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Extensions;
using UserManagementApi.Models.DBModels;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.AuthDTO;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;


namespace UserManagementApi.Repositories.AuthServicesRepo
{
    public class AuthServices : IAuthServices
    {
        private readonly DBManagementContext db;
        private readonly IMapper mapper;
        private readonly OtherServices otherServices = new();
        public AuthServices(DBManagementContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<ResponseModel> AuthUser(UserLoginDTO requestDto)
        {
            try
            {
                var existingUser = await db.tbl_users.FindAsync(Guid.Parse(requestDto.userId));
                if (existingUser != null)
                {
                    if (existingUser.password == otherServices.encodePassword(requestDto.password) && existingUser.user_username == requestDto.userUserName)
                    {
                        // Authentication successful
                        return new ResponseModel
                        {
                            remarks = "Success",
                            success = true,
                        };
                    }
                    else
                    {
                        // Authentication failed
                        if (existingUser.user_username != requestDto.userUserName)
                        {
                            return new ResponseModel
                            {
                                remarks = "Username is wrong",
                                success = false,
                            };
                        }
                        else
                        {
                            return new ResponseModel
                            {
                                remarks = "Password is wrong",
                                success = false,
                            };
                        }
                    }
                }
                else
                {
                    // Authentication failed
                    return new ResponseModel
                    {
                        remarks = "User not found",
                        success = false,
                    };
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return new ResponseModel
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly OtherServices otherServices;
        public AuthServices(DBManagementContext db, IMapper mapper, OtherServices otherServices)
        {
            this.db = db;
            this.mapper = mapper;
            this.otherServices = otherServices;
        }
        // correct this logic
        public async Task<ResponseModel> AuthUser(UserLoginDTO requestDto)
        {
            try
            {
                var existingUser = await db.tbl_users.Where(u => u.user_username == requestDto.userUserName).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    if (existingUser.password == otherServices.encodePassword(requestDto.password) )
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
                       
                        return new ResponseModel
                        {
                            remarks = "Password is wrong",
                            success = false,
                        };
                    
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
        public async Task<ResponseModel> ForgotPassword(ForgotPasswordDTO requestDto)
        {
            try
            {
                var user = await db.tbl_users.Where(u => u.user_email_address == requestDto.userEmailAddress).FirstOrDefaultAsync();
                if (user != null)
                {
                    // Generate a password reset token and send a reset email
                    // ... (code to generate token and send email)

                    return (new ResponseModel
                    {
                        success = true,
                        remarks = "Password reset email sent"
                    });
                }
                else
                {
                    // User not found
                    return (new ResponseModel
                    {
                        success = false,
                        remarks = "Email is wrong"
                    });
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
    }
}

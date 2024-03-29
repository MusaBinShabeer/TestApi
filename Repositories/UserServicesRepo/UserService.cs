﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApi.Models.DBModels;
using TestApi.Models.DBModels.DBTables;
using TestApi.Models.DTOs.ResponseDTO;
using TestApi.Models.DTOs.UserDTOs;

namespace TestApi.Repositories.UserServicesRepo
{
    public class UserService : IUserService
    {
        private readonly TestDBContext db;
        private readonly IMapper mapper;
        public UserService(TestDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<ResponseModel<UserResponseDTO>> AddUser(AddUserDTO requestDto)
        {
            try
            {
                var user = await db.tbl_users.Where(u => u.user_name.ToLower() == requestDto.userName.ToLower() && u.user_phone_no == requestDto.userPhoneNo).FirstOrDefaultAsync();
                if (user == null)
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
                else
                {
                    return new ResponseModel<UserResponseDTO>()
                    {
                        remarks = "User Already Exists",
                        success = false,
                    };
                }
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
                var existingUser = await db.tbl_users.FindAsync(Guid.Parse(requestDto.userId));
                if (existingUser != null)
                {
                    mapper.Map(requestDto, existingUser);
                    await db.SaveChangesAsync();
                    return new ResponseModel<UserResponseDTO>()
                    {
                        data = mapper.Map<UserResponseDTO>(existingUser),
                        remarks = "Success",
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<UserResponseDTO>()
                    {
                        remarks = "User not found",
                        success = false,
                    };
                }
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
        public async Task<ResponseModel<UserResponseDTO>> GetUserById(string userID)
        {
            try
            {
                var existingUser = await db.tbl_users.FindAsync(Guid.Parse(userID));
                if (existingUser != null)
                {
                    return new ResponseModel<UserResponseDTO>()
                    {
                        data = mapper.Map<UserResponseDTO>(existingUser),
                        remarks = "Success",
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<UserResponseDTO>()
                    {
                        remarks = "User not found",
                        success = false,
                    };
                }
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
        public async Task<ResponseModel<List<UserResponseDTO>>> GetAllUsers()
        {
            try
            {
                var allUsers = await db.tbl_users.ToListAsync();
                if (allUsers.Any())
                {
                    var userDTOs = allUsers.Select(existingUser => mapper.Map<UserResponseDTO>(existingUser)).ToList();
                    return new ResponseModel<List<UserResponseDTO>>()
                    {
                        data = userDTOs,
                        remarks = "Success",
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<List<UserResponseDTO>>()
                    {
                        remarks = "No users found",
                        success = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<UserResponseDTO>>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
        public async Task<ResponseModel> DeleteUserById(string userId)
        {
            try
            {
                var existingUser = await db.tbl_users.FindAsync(Guid.Parse(userId));
                if (existingUser != null)
                {
                    db.tbl_users.Remove(existingUser); // Mark the entity for deletion
                    await db.SaveChangesAsync();
                    return new ResponseModel()
                    {
                        remarks = "User deleted successfully",
                        success = true,
                    };
                }
                else
                {
                    return new ResponseModel()
                    {
                        remarks = "User not found",
                        success = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
    }
}

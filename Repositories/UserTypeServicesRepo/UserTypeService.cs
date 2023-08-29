using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models.DBModels;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;
using UserManagementApi.Models.DTOs.UserTypeDTOs;

namespace UserManagementApi.Repositories.UserTypeServicesRepo
{
    public class UserTypeService : IUserTypeService
    {
        private readonly DBManagementContext db;
        private readonly IMapper mapper;
        public UserTypeService(DBManagementContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<ResponseModel<UserTypeResponseDTO>> AddUserType(AddUserTypeDTO requestDto)
        {
            try
            {
                // check whether this type already exists or not
                var userType = await db.tbl_user_types.Where(u => u.type_name.ToLower() == requestDto.typeName.ToLower()).FirstOrDefaultAsync();
                if (userType == null)
                {
                    var newUserType = new tbl_user_type();
                    newUserType = mapper.Map<tbl_user_type>(requestDto);
                    await db.AddAsync(newUserType);
                    await db.SaveChangesAsync();
                    return new ResponseModel<UserTypeResponseDTO>()
                    {
                        data = mapper.Map<UserTypeResponseDTO>(newUserType),
                        remarks = "Success",
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<UserTypeResponseDTO>()
                    {
                        remarks = "User Type Already Exists",
                        success = false,
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
        public async Task<ResponseModel<List<UserTypeResponseDTO>>> GetUserType()
        {
            try
            {
                var userTypes = await db.tbl_user_types.ToListAsync();
                if (userTypes.Any())
                {
                    var userTypeResponseDTOs = mapper.Map<List<UserTypeResponseDTO>>(userTypes);
                    return new ResponseModel<List<UserTypeResponseDTO>>()
                    {
                        data = userTypeResponseDTOs,
                        remarks = "Success",
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<List<UserTypeResponseDTO>>()
                    {
                        remarks = "No user Type found",
                        success = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<UserTypeResponseDTO>>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
        public async Task<ResponseModel<UserTypeResponseDTO>> UpdateUserType(UpdateUserTypeDTO requestDto)
        {
            try
            {
                // change Update Logic
                var existingUserType = await db.tbl_user_types.FirstOrDefaultAsync(t => t.type_id == Guid.Parse(requestDto.typeId));
                if (existingUserType == null)
                {
                    return new ResponseModel<UserTypeResponseDTO>()
                    {
                        remarks = "User type not found",
                        success = false,
                    };
                }
                mapper.Map(requestDto, existingUserType);
                await db.SaveChangesAsync();
                return new ResponseModel<UserTypeResponseDTO>()
                {
                    data = mapper.Map<UserTypeResponseDTO>(existingUserType),
                    remarks = "Success",
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
        public async Task<ResponseModel<UserTypeResponseDTO>> GetUserTypeById(string typeId)
        {
            try
            {
                var userTypesById = await db.tbl_user_types.FindAsync(Guid.Parse(typeId)); // Assuming tbl_user_type is your Entity Framework DbSet
                if (userTypesById != null)
                {
                    var userTypeResponseDTOs = mapper.Map<UserTypeResponseDTO>(userTypesById);
                    return new ResponseModel<UserTypeResponseDTO>()
                    {
                        data = userTypeResponseDTOs,
                        remarks = "Success",
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<UserTypeResponseDTO>()
                    {
                        remarks = "User type not found",
                        success = false,
                    };
                }
         
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
        public async Task<ResponseModel<UserTypeResponseDTO>> DeleteById(string typeId)
        {
            try
            {
                // change logic
                var existingUserType = await db.tbl_user_types.FirstOrDefaultAsync(t => t.type_id == Guid.Parse(typeId));
                if (existingUserType == null)
                {
                    return new ResponseModel<UserTypeResponseDTO>()
                    {
                        remarks = "User type not found",
                        success = false
                    };
                }
                db.tbl_user_types.Remove(existingUserType);
                await db.SaveChangesAsync();
                var userTypeResponseDTO = mapper.Map<UserTypeResponseDTO>(existingUserType);
                return new ResponseModel<UserTypeResponseDTO>()
                {
                    data = userTypeResponseDTO ,
                    remarks = "User type deleted successfully",
                    success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = $"There was a fatal error {ex.ToString()}",
                    success = false,
                };
            }
        }
    }
}
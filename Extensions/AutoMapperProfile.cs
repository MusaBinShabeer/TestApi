using AutoMapper;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.UserDTOs;

namespace UserManagementApi.Extensions
{
    public class AutoMapperProfile : Profile
    {
        private readonly OtherServices otherServices = new();
        public AutoMapperProfile()
        {
            CreateMap<AddUserDTO, tbl_user>()
              .ForMember(d => d.user_first_name, opt => opt.MapFrom(src => src.userFirstName))
              .ForMember(d => d.user_last_name, opt => opt.MapFrom(src => src.userLastName))
              .ForMember(d => d.fk_user_type, opt => opt.MapFrom(src => Guid.Parse(src.fkUserType)))
              .ForMember(d => d.user_email_address, opt => opt.MapFrom(src => src.userEmailAddress))
              .ForMember(d => d.user_phone_no, opt => opt.MapFrom(src => src.userPhoneNo))
              .ForMember(d => d.password, opt => opt.MapFrom(src => otherServices.encodePassword(src.password)))
              .ForMember(d => d.user_username, opt => opt.MapFrom(src => src.userUserName));
            CreateMap<UpdateUserDTO, tbl_user>()
              .ForMember(d => d.user_id, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userId) ? Guid.Parse(src.userId) : dest.user_id))
              .ForMember(d => d.user_first_name, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userFirstName) ? src.userFirstName : dest.user_first_name))
              .ForMember(d => d.user_last_name, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userLastName) ? src.userLastName : dest.user_last_name))
              .ForMember(d => d.fk_user_type, opt => opt.MapFrom((src, dest) => otherServices.Check(src.fkUserType) ? Guid.Parse(src.fkUserType) : dest.fk_user_type))
              .ForMember(d => d.user_phone_no, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userPhoneNo) ? src.userPhoneNo : dest.user_phone_no))
              .ForMember(d => d.password, opt => opt.MapFrom((src, dest) => otherServices.Check(src.password) ? otherServices.encodePassword(src.password) : dest.password))
              .ForMember(d => d.user_email_address, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userEmailAddress) ? src.userEmailAddress : dest.user_email_address))
              .ForMember(d => d.user_username, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userUserName) ? src.userUserName : dest.user_username));
            CreateMap<tbl_user, UserResponseDTO>()
              .ForMember(d => d.userId, opt => opt.MapFrom(src => src.user_id))
              .ForMember(d => d.userFirstName, opt => opt.MapFrom(src => src.user_first_name))
              .ForMember(d => d.userLastName, opt => opt.MapFrom(src => src.user_last_name))
              .ForMember(d => d.fkUserType, opt => opt.MapFrom(src => src.fk_user_type))
              .ForMember(d => d.userEmailAddress, opt => opt.MapFrom(src => src.user_email_address))
              .ForMember(d => d.userPhoneNo, opt => opt.MapFrom(src => src.user_phone_no))
              .ForMember(d => d.password, opt => opt.MapFrom(src => otherServices.encodePassword(src.password)))
              .ForMember(d => d.userUserName, opt => opt.MapFrom(src => src.user_username));
        }
    }
}

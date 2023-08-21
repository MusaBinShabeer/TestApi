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
        //    CreateMap<UpdateUserDTO, tbl_user>()
        //      .ForMember(d => d.user_id, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userId) ? Guid.Parse(src.userId) : dest.user_id))
        //      .ForMember(d => d.user_first_name, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userFirstName) ? src.userFirstName : dest.user_first_name))
        //      .ForMember(d => d.user_last_name, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userLastName) ? src.userLastName : dest.user_last_name))
        //      .ForMember(d => d.fk_user_type, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userTypeId) ? Guid.Parse(src.userTypeId) : dest.fk_user_type))
        //      .ForMember(d => d.user_designation, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userDesignation) ? src.userDesignation : dest.user_designation))
        //      .ForMember(d => d.user_phone, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userPhone) ? src.userPhone : dest.user_phone))
        //      .ForMember(d => d.user_password, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userPassword) ? otherServices.encodePassword(src.userPassword) : dest.user_password))
        //      .ForMember(d => d.user_email, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userEmail) ? src.userEmail : dest.user_email));
        //
        }
    }
}

using AutoMapper;
using UserManagementApi.Models.DBModels.DBTables;
using UserManagementApi.Models.DTOs.UserDTOs;
using UserManagementApi.Models.DTOs.UserTypeDTOs;

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
           
CreateMap<tbl_user, UserResponseDTO>()
                .ForMember(d=> d.userId , opt => opt.MapFrom(src=> src.user_id))
    .ForMember(d => d.userFirstName, opt => opt.MapFrom(src => src.user_first_name))
    .ForMember(d => d.userLastName, opt => opt.MapFrom(src => src.user_last_name))
    .ForMember(d => d.fkUserType, opt => opt.MapFrom(src => src.fk_user_type.ToString()))
    .ForMember(d => d.userEmailAddress, opt => opt.MapFrom(src => src.user_email_address))
    .ForMember(d => d.userPhoneNo, opt => opt.MapFrom(src => src.user_phone_no))
    .ForMember(d => d.password, opt => opt.MapFrom(src => otherServices.encodePassword(src.password))) // Avoid mapping sensitive data
    .ForMember(d => d.userUserName, opt => opt.MapFrom(src => src.user_username));


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
            CreateMap<AddUserTypeDTO, tbl_user_type>()
            .ForMember(d => d.type_name, opt => opt.MapFrom(src => src.typeName));

            CreateMap<UpdateUserTypeDTO, tbl_user_type>()
                .ForMember(d => d.type_name, opt => opt.MapFrom(src => src.typeName));
               

            CreateMap<tbl_user_type, UserTypeResponseDTO>()
        .ForMember(d => d.typeId, opt => opt.MapFrom(src => src.type_id))
        .ForMember(d => d.typeName, opt => opt.MapFrom(src => src.type_name))
        .ForMember(d => d.isActive, opt => opt.MapFrom(src => src.is_active))
       .ForMember(d => d.users, opt => opt.Ignore());
        }




    }
    
}

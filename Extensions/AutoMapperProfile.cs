using AutoMapper;
using TestApi.Models.DBModels.DBTables;
using TestApi.Models.DTOs.UserDTOs;

namespace TestApi.Extensions
{
    public class AutoMapperProfile : Profile
    {
        private readonly OtherServices otherServices = new();
        public AutoMapperProfile()
        {
            #region User
            CreateMap<AddUserDTO, tbl_user>()
              .ForMember(d => d.user_name, opt => opt.MapFrom(src => src.userName))
              .ForMember(d => d.user_gender, opt => opt.MapFrom(src => src.userGender))
              .ForMember(d => d.user_phone_no, opt => opt.MapFrom(src => src.userPhoneNo))
              .ForMember(d => d.click, opt => opt.MapFrom(src => src.userClick));
            CreateMap<AddUserDTO, AddUserTestDTO>()
             .ForMember(d => d.userName, opt => opt.MapFrom(src => src.userName))
             .ForMember(d => d.userGender, opt => opt.MapFrom(src => src.userGender))
             .ForMember(d => d.userPhoneNo, opt => opt.MapFrom(src => src.userPhoneNo))
             .ForMember(d => d.userClick, opt => opt.MapFrom(src => src.userClick));
            CreateMap<UpdateUserDTO, tbl_user>()
              .ForMember(d => d.user_id, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userId) ? Guid.Parse(src.userId) : dest.user_id))
              .ForMember(d => d.user_name, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userName) ? src.userName : dest.user_name))
              .ForMember(d => d.user_phone_no, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userPhoneNo) ? src.userPhoneNo : dest.user_phone_no))
              .ForMember(d => d.click, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userClick) ? (src.userClick) : dest.click))
              .ForMember(d => d.user_gender, opt => opt.MapFrom((src, dest) => otherServices.Check(src.userGender) ? src.userGender : dest.user_gender));
            CreateMap<tbl_user, UserResponseDTO>()
              .ForMember(d => d.userId, opt => opt.MapFrom(src => src.user_id))
              .ForMember(d => d.userName, opt => opt.MapFrom(src => src.user_name))
              .ForMember(d => d.userGender, opt => opt.MapFrom(src => src.user_gender))
              .ForMember(d => d.userPhoneNo, opt => opt.MapFrom(src => src.user_phone_no))
              .ForMember(d => d.userClick, opt => opt.MapFrom(src => src.click));
            #endregion
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;

namespace UserManagementApi.Repositories.JWTUtilsRepo
{
    public interface IJWTUtils
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims, bool isRememberMeActive);
        public Task<ResponseModel<UserResponseDTO>> ValidateToken(string userToken);
    }
}

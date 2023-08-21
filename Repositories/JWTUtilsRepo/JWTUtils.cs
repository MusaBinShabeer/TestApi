using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementApi.Models.DBModels;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;

namespace UserManagementApi.Repositories.JWTUtilsRepo
{
    public class JWTUtils : IJWTUtils
    {
        private readonly IConfiguration _configuration;
        private readonly DBManagementContext db;
        private readonly IMapper _mapper;
        public JWTUtils(IConfiguration configuration, DBManagementContext db, IMapper mapper)
        {
            _configuration = configuration;
            this.db = db;
            _mapper = mapper;
        }
        public JwtSecurityToken GetToken(List<Claim> authClaims, bool isRememberMeActive)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                expires: isRememberMeActive ? DateTime.UtcNow.AddHours(29) : DateTime.UtcNow.AddHours(8),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        public async Task<ResponseModel<UserResponseDTO>> ValidateToken(string userToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            tokenHandler.ValidateToken(userToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                //set clockskew to zero so tokens expire exactly at token expiration time(instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var email = jwtToken.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            if (email != null)
            {
                var user = await db.tbl_users.Where(x => x.user_email_address == email && x.user_token == userToken).FirstOrDefaultAsync();
                if (user != null)
                {

                    return new ResponseModel<UserResponseDTO>()
                    {
                        data = _mapper.Map<UserResponseDTO>(user),
                        success = true
                    };
                }
                else
                {
                    return new ResponseModel<UserResponseDTO>()
                    {
                        success = false
                    };
                }
            }
            else
            {
                return new ResponseModel<UserResponseDTO>() { success = false };
            }
        }
    }
}

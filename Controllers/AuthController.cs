using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models.DTOs.AuthDTO;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Repositories.AuthServicesRepo;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices authService;
        public AuthController(IAuthServices authService) { this.authService = authService; }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> UserAuthentication(UserLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var Response = authService.AuthUser(model);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }

        [Route("forgot-password")]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> ForgotPassword(ForgotPasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                var Response = authService.ForgotPassword(model);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }
    }
}

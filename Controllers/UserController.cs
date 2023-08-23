using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Extensions.MiddleWare;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;
using UserManagementApi.Repositories.UserServicesRepo;

namespace UserManagementApi.Controllers
{
    //[ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService) { this.userService = userService; }
        [HttpPost]
        public async Task<ActionResult<ResponseModel<UserResponseDTO>>> Post(AddUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var Response = userService.AddUser(model);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel<UserResponseDTO>()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }
        [Route("api/[controller]")]
        [HttpPut]
        public async Task<ActionResult<ResponseModel<UserResponseDTO>>> Put(UpdateUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var Response = userService.UpdateUser(model);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel<UserResponseDTO>()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }
    }
}

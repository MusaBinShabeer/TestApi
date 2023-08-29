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
        // other service
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
        [HttpGet]
        public async Task<ActionResult<ResponseModel<UserResponseDTO>>> GetUserById(string UserID)
        {
            if (ModelState.IsValid)
            {
                var Response = userService.GetUserById(UserID);
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
        [Route("AllUsers")]
        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<UserResponseDTO>>>> GetAllUsers()
        {
            // remove model state
            if (ModelState.IsValid)
            {
                var Response = userService.GetAllUsers();
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
        [HttpDelete]
        public async Task<ActionResult<ResponseModel>> DeleteUserById(string Id)
        {
            // if(otherservice.Check(UserId)
            if (ModelState.IsValid)
            {
                var Response = userService.DeleteUserById(UserID);
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

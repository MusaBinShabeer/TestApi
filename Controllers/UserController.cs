using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Extensions;
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
        private readonly OtherServices otherServices;
        
        public UserController(IUserService userService, OtherServices otherServices)
        { 
            this.userService = userService; 
            this.otherServices = otherServices; 
        }

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
        public async Task<ActionResult<ResponseModel<UserResponseDTO>>> GetUserById(string ID)
        {
            if (otherServices.Check(ID))
            {
                var Response = userService.GetUserById(ID);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel<UserResponseDTO>()
                {
                    remarks = "User not found by ID",
                    success = false
                };
                return BadRequest(Response);
            }
        }
        [Route("AllUsers")]
        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<UserResponseDTO>>>> GetAllUsers()
        {
            var users = await userService.GetAllUsers(); 
            if (users != null)
            {
                var Response = users;
                return Ok(Response);
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
            if(otherServices.Check(Id))
            {
                var Response = userService.DeleteUserById(Id);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel<UserResponseDTO>()
                {
                    remarks = "User not found by ID",
                    success = false
                };
                return BadRequest(Response);
            }
        }
    }
}

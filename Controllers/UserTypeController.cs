using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models.DTOs.ResponseDTO;
using UserManagementApi.Models.DTOs.UserDTOs;
using UserManagementApi.Models.DTOs.UserTypeDTOs;
using UserManagementApi.Repositories.UserServicesRepo;
using UserManagementApi.Repositories.UserTypeServicesRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService userTypeService;
        public UserTypeController(IUserTypeService userTypeService) { this.userTypeService = userTypeService; }

        // POST api/<UserTypeController>
        [HttpPost]
        public async Task<ActionResult<ResponseModel<UserTypeResponseDTO>>> Post(AddUserTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                var Response = userTypeService.AddUserType(model);
                return Ok(await Response);
            }
            else
            {
                var Response = new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }
        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<UserTypeResponseDTO>>>> Get()
        {
            if (ModelState.IsValid)
            {
                var response = await userTypeService.GetUserType(); // Assuming you have a GetUserTypes method in your service
                return Ok(response);
            }
            else
            {
                var Response = new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }
        [HttpGet("typeId")]
        public async Task<ActionResult<ResponseModel<List<UserTypeResponseDTO>>>> GetById(string Id)
        {
            if (ModelState.IsValid)
            {
                var response = await userTypeService.GetUserTypeById(typeId); // Assuming you have a GetUserTypes method in your service
                return Ok(response);
            }
            else
            {
                var Response = new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(Response);
            }
        }

        [HttpPut("{typeId}")]
        public async Task<ActionResult<ResponseModel<UserTypeResponseDTO>>> Put(UpdateUserTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = userTypeService.UpdateUserType(model);
                return Ok(await response);
            }
            else
            {
                var response = new ResponseModel<UserTypeResponseDTO>()
                {
                    remarks = "Model Not Verified",
                    success = false
                };
                return BadRequest(response);
            }
        }

        [HttpDelete("{typeId}")]
        public async Task<ActionResult<ResponseModel<UserTypeResponseDTO>>> DeleteById(string Id)
        {
            var response = await userTypeService.DeleteById(Id);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}

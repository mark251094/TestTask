using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestTask.Common.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-user")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        public IActionResult Create([FromBody] UserCreateModel request)
        {
            try
            {
                var result = _userService.Create(request);

                return Ok(result);
            }
            catch(ExpectedException e)
            {
                return BadRequest(new { errors = e.Message });

            }      
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);

                return Ok();
            }
            catch (ExpectedException e)
            {
                return BadRequest(new { errors = e.Message });
            }
        }

        [HttpPut("update-user")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        public IActionResult Update([FromBody] UserUpdateModel request)
        {
            try
            {
                var result = _userService.Update(request);

                return Ok(result);
            }
            catch (ExpectedException e)
            {
                return BadRequest(new { errors = e.Message });
            }        
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(UserListViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            return Ok(result);
        }
    }
}

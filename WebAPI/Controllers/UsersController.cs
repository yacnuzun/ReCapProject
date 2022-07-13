using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;

        public UsersController(IUserService UserService)
        {
            _userService = UserService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _userService.GetById(Id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //[HttpPost("add")]
        //public IActionResult Add(User User)
        //{
        //    var result = _userService.Add(User);
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);

        //}
        [HttpPost("update")]
        public IActionResult Update(User User)
        {
            var result = _userService.Update(User);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(User User)
        {
            var result = _userService.Delete(User);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}


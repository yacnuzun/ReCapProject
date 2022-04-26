using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _customerService = CustomerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getcustomerdetail")]
        public IActionResult GetCustomerDetail()
        {
            var result = _customerService.GetCustomerDetail();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _customerService.GetById(Id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Customer Customer)
        {
            var result = _customerService.Add(Customer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Customer Customer)
        {
            var result = _customerService.Update(Customer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer Customer)
        {
            var result = _customerService.Delete(Customer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

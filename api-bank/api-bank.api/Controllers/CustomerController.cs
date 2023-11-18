using api_bank.domain.Dtos;
using api_bank.domain.Dtos.CustomerDto;
using api_bank.domain.Results;
using api_bank.domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_bank.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(
            ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService= customerService;
        }
        [HttpPost("createcustomer")]
        public async Task<IActionResult> PostCreateCustomerAsync([FromBody] AddCustomerDto entity)
        {
            var resultService = await _customerService.AddAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpPut("updatecustomer")]
        public async Task<IActionResult> PutCreateCustomerAsync([FromBody] UpdateCustomerDto entity)
        {
            var resultService = await _customerService.UpdateAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getcustomerbyfilters/{page}/{count}")]
        public async Task<IActionResult> GetCustomerByFiltersAsync([FromQuery] FilterCustomerDto filterCustomerDto, int page, int count)
        {
            var resultService = await _customerService.GetByFiltersAsync(filterCustomerDto, new PaginationDto(page, count));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
    }
}

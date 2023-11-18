using api_bank.domain.Dtos;
using api_bank.domain.Dtos.BankDto;
using api_bank.domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_bank.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;
        private readonly IBankService _bankService;
        public BankController(
            ILogger<BankController> logger,
            IBankService bankService)
        {
            _logger = logger;
            _bankService= bankService;
        }
        [HttpPost("createbank")]
        public async Task<IActionResult> PostCreateExtractAsync([FromBody] AddBankDto entity)
        {
            var resultService = await _bankService.AddAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getbankall/{page}/{count}")]
        public async Task<IActionResult> GetBankAllAsync(int page, int count)
        {

            var resultService = await _bankService.GetAllAsync(new PaginationDto(page, count));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
    }
}
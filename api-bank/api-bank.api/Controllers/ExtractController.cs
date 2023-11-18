using api_bank.domain.Dtos;
using api_bank.domain.Results;
using api_bank.domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace api_bank.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtractController : ControllerBase
    {
        private readonly ILogger<ExtractController> _logger;
        private readonly IExtractService _extractService;
        public ExtractController(
            ILogger<ExtractController> logger,
            IExtractService customerService)
        {
            _logger = logger;
            _extractService= customerService;
        }
        [HttpPost("createextract")]
        public async Task<IActionResult> PostCreateExtractAsync([FromBody] AddExtractDto entity)
        {
            var resultService = await _extractService.AddAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpPut("updateextract")]
        public async Task<IActionResult> PutCreateExtractAsync([FromBody] UpdateExtractDto entity)
        {
            var resultService = await _extractService.UpdateAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getextractbyfilters/{page}/{count}")]
        public async Task<IActionResult> GetExtractByFiltersAsync([FromQuery] FilterExtractDto filterExtractDto, int page, int count)
        {
            var resultService = await _extractService.GetByFiltersAsync(filterExtractDto, new PaginationDto(page, count));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getextractall/{page}/{count}")]
        public async Task<IActionResult> GetExtractAllAsync(int page, int count)
        {
            var resultService = await _extractService.GetAllAsync(new PaginationDto(page, count));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
    }
}
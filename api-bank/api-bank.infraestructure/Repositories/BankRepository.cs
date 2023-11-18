using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.Repositories;
using api_bank.domain.Results;
using api_bank.infraestructure.Factory;
using api_bank.utility.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api_bank.infraestructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BankRepository> _logger;
        public BankRepository(AppDbContext dbContext, ILogger<BankRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<ResultRepository<BankEntity>> AddAsync(BankEntity bankEntity)
        {
            try
            {
                var newEntity = await _dbContext
                     .BankEntities
                     .AddAsync(bankEntity);

                await _dbContext
                    .SaveChangesAsync();

                return ResultsHelpers
                    .ReturnResultRepository<BankEntity>(true, newEntity.State.ToString(), newEntity.Entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers
                    .ReturnResultRepository<BankEntity>(false, Exception.Message, new BankEntity());
            }
        }
        public async Task<ResultRepository<List<BankEntity>>> GetAllAsync(PaginationDto paginationDto)
        {
            try
            {
                var getEntity = await _dbContext
                  .BankEntities
                  .OrderBy(m => m.Id)
                  .Skip(paginationDto.Count * (paginationDto.Page - 1))
                  .Take(paginationDto.Count)
                  .Include(c => c.CustomerEntitys)
                  .Include(c => c.ExtractEntitys)
                  .ToListAsync();

                return ResultsHelpers
                    .ReturnResultRepository<BankEntity>(true, "", getEntity.ToList());
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers
                    .ReturnResultRepository<BankEntity>(false, Exception.Message, new List<BankEntity>());
            }
        }       
    }
}
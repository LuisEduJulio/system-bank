using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.Enums;
using api_bank.domain.Repositories;
using api_bank.domain.Results;
using api_bank.infraestructure.Factory;
using api_bank.utility.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api_doc_rabbitmq.infraestructure.Repositories
{
    public class ExtractRepository : IExtractRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ExtractRepository> _logger;
        public ExtractRepository(AppDbContext dbContext, ILogger<ExtractRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<ResultRepository<ExtractEntity>> AddAsync(ExtractEntity extractEntity)
        {
            try
            {
                var newEntity = await _dbContext
                     .ExtractEntities
                     .AddAsync(extractEntity);

                await _dbContext.SaveChangesAsync();

                return ResultsHelpers
                    .ReturnResultRepository<ExtractEntity>(true, newEntity.State.ToString(), newEntity.Entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers
                    .ReturnResultRepository<ExtractEntity>(false, Exception.Message, new ExtractEntity());
            }
        }

        public async Task<ResultRepository<List<ExtractEntity>>> GetAllAsync(PaginationDto paginationDto)
        {
            try
            {
                var getEntity = await _dbContext
                  .ExtractEntities
                  .OrderBy(m => m.Id)
                  .Skip(paginationDto.Count * (paginationDto.Page - 1))
                  .Take(paginationDto.Count)
                  .ToListAsync();

                return ResultsHelpers.ReturnResultRepository<ExtractEntity>(true, "", getEntity.ToList());
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers.ReturnResultRepository<ExtractEntity>(false, Exception.Message, new List<ExtractEntity>());
            }
        }

        public async Task<ResultRepository<List<ExtractEntity>>> GetByFiltersAsync(ExtractEntity extractEntity, PaginationDto paginationDto)
        {
            try
            {
                var query = _dbContext
                    .ExtractEntities
                    .AsQueryable();

                if (extractEntity.Id > 0)
                {
                    query = query.Where(e => e.Id == extractEntity.Id);
                }

                if (!string.IsNullOrEmpty(extractEntity.Describe))
                {
                    query = query
                        .Where(e => e.Describe.Contains(extractEntity.Describe));
                }

                if (extractEntity.EExtractType != EExtractType.None)
                {
                    query = query
                        .Where(e => e.EExtractType == extractEntity.EExtractType);
                }

                if (extractEntity.CustomerEntityId > 0)
                {
                    query = query
                        .Where(e => e.CustomerEntityId == extractEntity.CustomerEntityId);
                }

                if (extractEntity.BankEntityId > 0)
                {
                    query = query
                        .Where(e => e.BankEntityId == extractEntity.BankEntityId);
                }

                if (extractEntity.DateCreation != default(DateTime))
                {
                    query = query
                        .Where(e => e.DateCreation.Value.Date == extractEntity.DateCreation.Value.Date);
                }

                var getEntity = await query
                    .OrderBy(e => e.Id)
                    .Skip(paginationDto.Count * (paginationDto.Page - 1))
                    .Take(paginationDto.Count)
                    .ToListAsync();

                return ResultsHelpers
                    .ReturnResultRepository<ExtractEntity>(true, "", getEntity.ToList());
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers
                    .ReturnResultRepository<ExtractEntity>(false, Exception.Message, new List<ExtractEntity>());
            }
        }
        public async Task<ResultRepository<ExtractEntity>> UpdateAsync(ExtractEntity extractEntity)
        {
            try
            {
                var updateEntity = _dbContext
                     .ExtractEntities
                     .Update(extractEntity);

                await _dbContext.SaveChangesAsync();

                return ResultsHelpers
                    .ReturnResultRepository<ExtractEntity>(true, updateEntity.State.ToString(), updateEntity.Entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers
                    .ReturnResultRepository<ExtractEntity>(false, Exception.Message, new ExtractEntity());
            }
        }
    }
}
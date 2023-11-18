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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(AppDbContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<ResultRepository<CustomerEntity>> AddAsync(CustomerEntity customerEntity)
        {
            try
            {
                var newEntity = await _dbContext
                     .CustomerEntities
                     .AddAsync(customerEntity);

                await _dbContext.SaveChangesAsync();

                return ResultsHelpers.ReturnResultRepository<CustomerEntity>(true, newEntity.State.ToString(), newEntity.Entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers.ReturnResultRepository<CustomerEntity>(false, Exception.Message, new CustomerEntity());
            }
        }
        public async Task<ResultRepository<List<CustomerEntity>>> GetByFiltersAsync(CustomerEntity customerEntity, PaginationDto paginationDto)
        {
            try
            {
                var query = _dbContext
                    .CustomerEntities
                    .AsQueryable();

                if (customerEntity.Id != 0)
                {
                    query = query.Where(m => m.Id == customerEntity.Id);
                }

                if (!string.IsNullOrEmpty(customerEntity.Name))
                {
                    query = query.Where(m => m.Name.Contains(customerEntity.Name));
                }

                if (!string.IsNullOrEmpty(customerEntity.LastName))
                {
                    query = query.Where(m => m.LastName.Contains(customerEntity.LastName));
                }

                if (!string.IsNullOrEmpty(customerEntity.Email))
                {
                    query = query.Where(m => m.Email.Contains(customerEntity.Email));
                }

                if (customerEntity.BankEntityId > 0)
                {
                    query = query.Where(m => m.BankEntityId == customerEntity.BankEntityId);
                }

                var getEntity = await query
                    .OrderBy(m => m.Id)
                    .Skip(paginationDto.Count * (paginationDto.Page - 1))
                    .Take(paginationDto.Count)
                    .Include(e => e.ExtractEntitys)
                    .Include(e => e.BankEntity)
                    .ToListAsync();

                return ResultsHelpers.ReturnResultRepository<CustomerEntity>(true, "", getEntity.ToList());
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers.ReturnResultRepository<CustomerEntity>(false, Exception.Message, new List<CustomerEntity>());
            }
        }
        public async Task<ResultRepository<CustomerEntity>> UpdateAsync(CustomerEntity customerEntity)
        {
            try
            {
                var updateEntity = _dbContext
                     .CustomerEntities
                     .Update(customerEntity);

                await _dbContext.SaveChangesAsync();

                return ResultsHelpers
                    .ReturnResultRepository<CustomerEntity>(true, updateEntity.State.ToString(), updateEntity.Entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(message: Exception.Message);

                return ResultsHelpers.ReturnResultRepository<CustomerEntity>(false, Exception.Message, new CustomerEntity());
            }
        }
    }
}
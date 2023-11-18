using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.Results;

namespace api_bank.domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<ResultRepository<CustomerEntity>> AddAsync(CustomerEntity entity);
        Task<ResultRepository<CustomerEntity>> UpdateAsync(CustomerEntity entity);
        Task<ResultRepository<List<CustomerEntity>>> GetByFiltersAsync(CustomerEntity entity, PaginationDto paginationDto);
    }
}
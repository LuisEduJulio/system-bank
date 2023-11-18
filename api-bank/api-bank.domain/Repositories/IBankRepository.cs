using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.Results;

namespace api_bank.domain.Repositories
{
    public interface IBankRepository
    {
        Task<ResultRepository<BankEntity>> AddAsync(BankEntity bankEntity);
        Task<ResultRepository<List<BankEntity>>> GetAllAsync(PaginationDto paginationDto);
    }
}

using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.Results;

namespace api_bank.domain.Repositories
{
    public interface IExtractRepository
    {
        Task<ResultRepository<ExtractEntity>> AddAsync(ExtractEntity entity);
        Task<ResultRepository<ExtractEntity>> UpdateAsync(ExtractEntity entity);
        Task<ResultRepository<List<ExtractEntity>>> GetByFiltersAsync(ExtractEntity entity, PaginationDto paginationDto);
        Task<ResultRepository<List<ExtractEntity>>> GetAllAsync(PaginationDto paginationDto);
    }
}
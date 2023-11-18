using api_bank.domain.Dtos;
using api_bank.domain.ModelView.ExtractModelView;
using api_bank.domain.Results;

namespace api_bank.domain.Services
{
    public interface IExtractService
    {
        Task<ResultService<AddExtractModelView>> AddAsync(AddExtractDto addExtractDto);
        Task<ResultService<UpdateExtractModelView>> UpdateAsync(UpdateExtractDto updateExtractDto);
        Task<ResultService<GetExtractAllModelView>> GetByFiltersAsync(FilterExtractDto filterExtractDto, PaginationDto paginationDto);
        Task<ResultService<GetExtractAllModelView>> GetAllAsync(PaginationDto paginationDto);
        Task<ResultService<DisabledExtractModelView>> UpdateDisabledAsync(DisabledExtractDto disabledExtractDto);
    }
}
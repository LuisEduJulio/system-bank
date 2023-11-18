using api_bank.domain.Dtos;
using api_bank.domain.Dtos.CustomerDto;
using api_bank.domain.ModelView.CustomerModelView;
using api_bank.domain.Results;

namespace api_bank.domain.Services
{
    public interface ICustomerService
    {
        Task<ResultService<AddCustomerModelView>> AddAsync(AddCustomerDto addCustomerDto);
        Task<ResultService<GetCustomerAllModelView>> GetByFiltersAsync(FilterCustomerDto filterCustomerDto, PaginationDto paginationDto);
        Task<ResultService<UpdateCustomerModelView>> UpdateAsync(UpdateCustomerDto updateCustomerDto);
    }
}
using api_bank.domain.Dtos;
using api_bank.domain.Dtos.BankDto;
using api_bank.domain.ModelView.BankModelView;
using api_bank.domain.Results;

namespace api_bank.domain.Services
{
    public interface IBankService
    {
        Task<ResultService<AddBankModelView>> AddAsync(AddBankDto addBankDto);
        Task<ResultService<GetBankAllModelView>> GetAllAsync(PaginationDto paginationDto);
    }
}
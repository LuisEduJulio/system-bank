using api_bank.application.Validations.Bank;
using api_bank.application.Validators;
using api_bank.domain.Dtos;
using api_bank.domain.Dtos.BankDto;
using api_bank.domain.Entities;
using api_bank.domain.ModelView.BankModelView;
using api_bank.domain.Repositories;
using api_bank.domain.Results;
using api_bank.domain.Services;
using api_bank.utility.Helpers;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace api_bank.application.Services
{
    public class BankService : IBankService
    {
        private readonly ILogger<BankService> _logger;
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;
        public BankService(
            ILogger<BankService> logger,
            IBankRepository bankRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<AddBankModelView>> AddAsync(AddBankDto addBankDto)
        {
            var validation = await new AddBankDtoValidator()
                .ValidateAsync(addBankDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<AddBankModelView>(false, validation.Errors.First().ErrorMessage, new AddBankModelView());

            var bankEntityMapper = _mapper
                .Map<BankEntity>(addBankDto);

            var bankEntity = await _bankRepository
                .AddAsync(bankEntityMapper);

            if (!bankEntity.Success) return ResultsHelpers
                    .ReturnResulService<AddBankModelView>(false, bankEntity.Message, _mapper.Map<AddBankModelView>(bankEntityMapper));

            var addBankModelView = _mapper
                .Map<AddBankModelView>(bankEntity.Data);

            return ResultsHelpers
                .ReturnResulService<AddBankModelView>(true, "Create Bank!", addBankModelView);
        }
        public async Task<ResultService<GetBankAllModelView>> GetAllAsync(PaginationDto paginationDto)
        {
            var validation = await new PaginationDtoValidator()
                .ValidateAsync(paginationDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<GetBankAllModelView>(false, validation.Errors.First().ErrorMessage, new GetBankAllModelView());

            var bankEntity = await _bankRepository
                .GetAllAsync(paginationDto);

            if (!bankEntity.Success) return ResultsHelpers
                    .ReturnResulService<GetBankAllModelView>(false, bankEntity.Message, new GetBankAllModelView());

            var getBankAllModelView = new GetBankAllModelView();

            foreach (var data in bankEntity.Data)
            {
                var getBankModelView = _mapper
                    .Map<GetBankModelView>(data);

                getBankAllModelView
                    .GetBanksModelView
                    .Add(getBankModelView);
            }

            return ResultsHelpers.ReturnResulService<GetBankAllModelView>(true, "List Bank!", getBankAllModelView);
        }

    }
}
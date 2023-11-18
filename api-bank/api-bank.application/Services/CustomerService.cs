using api_bank.application.Validators;
using api_bank.application.Validators.Customer;
using api_bank.domain.Dtos;
using api_bank.domain.Dtos.CustomerDto;
using api_bank.domain.Entities;
using api_bank.domain.ModelView.CustomerModelView;
using api_bank.domain.Repositories;
using api_bank.domain.Results;
using api_bank.domain.Services;
using api_bank.utility.Helpers;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace api_bank.application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(
            ILogger<CustomerService> logger,
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<AddCustomerModelView>> AddAsync(AddCustomerDto addCustomerDto)
        {
            var validation = await new AddCustomerDtoValidator()
                .ValidateAsync(addCustomerDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<AddCustomerModelView>(false, validation.Errors.First().ErrorMessage, new AddCustomerModelView());

            var customerEntityMapper = _mapper.Map<CustomerEntity>(addCustomerDto);

            var customerEntity = await _customerRepository.AddAsync(customerEntityMapper);

            if (!customerEntity.Success) return ResultsHelpers
                    .ReturnResulService<AddCustomerModelView>(false, customerEntity.Message, _mapper.Map<AddCustomerModelView>(customerEntityMapper));

            var addCustomerModelView = _mapper.Map<AddCustomerModelView>(customerEntity.Data);

            return ResultsHelpers
                .ReturnResulService<AddCustomerModelView>(true, "Create Customer!", addCustomerModelView);
        }
        public async Task<ResultService<GetCustomerAllModelView>> GetByFiltersAsync(FilterCustomerDto filterCustomerDto, PaginationDto paginationDto)
        {
            var validation = await new PaginationDtoValidator().ValidateAsync(paginationDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<GetCustomerAllModelView>(false, validation.Errors.First().ErrorMessage, new GetCustomerAllModelView());

            var customerEntityMapper = _mapper.Map<CustomerEntity>(filterCustomerDto);

            var customerEntity = await _customerRepository.GetByFiltersAsync(customerEntityMapper, paginationDto);

            if (!customerEntity.Success) return ResultsHelpers
                    .ReturnResulService<GetCustomerAllModelView>(false, customerEntity.Message, new GetCustomerAllModelView());

            var getCustomerAllModelView = new GetCustomerAllModelView();

            foreach (var data in customerEntity.Data)
            {
                var getCustomerModelView = _mapper.Map<GetCustomerModelView>(data);

                getCustomerAllModelView
                    .GetCustomersModelView
                    .Add(getCustomerModelView);
            }

            return ResultsHelpers
                .ReturnResulService<GetCustomerAllModelView>(true, "List Customer!", getCustomerAllModelView);
        }
        public async Task<ResultService<UpdateCustomerModelView>> UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            var validation = await new UpdateCustomerDtoValidator()
                .ValidateAsync(updateCustomerDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<UpdateCustomerModelView>(false, validation.Errors.First().ErrorMessage, new UpdateCustomerModelView());

            var customerEntityMapper = _mapper
                .Map<CustomerEntity>(updateCustomerDto);

            var customerEntity = await _customerRepository
                .UpdateAsync(customerEntityMapper);

            if (!customerEntity.Success) return ResultsHelpers
                  .ReturnResulService<UpdateCustomerModelView>(false, customerEntity.Message, _mapper.Map<UpdateCustomerModelView>(customerEntityMapper));

            var updateCustomerModelView = _mapper
                .Map<UpdateCustomerModelView>(customerEntity.Data);

            return ResultsHelpers
                .ReturnResulService<UpdateCustomerModelView>(true, "Update Customer!", updateCustomerModelView);
        }
    }
}
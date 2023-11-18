using api_bank.application.Validators;
using api_bank.application.Validators.Extract;
using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.ModelView.ExtractModelView;
using api_bank.domain.Repositories;
using api_bank.domain.Results;
using api_bank.domain.Services;
using api_bank.utility.Helpers;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace api_bank.application.Services
{
    public class ExtractService : IExtractService
    {
        private readonly ILogger<ExtractService> _logger;
        private readonly IExtractRepository _extractRepository;
        private readonly IMapper _mapper;
        public ExtractService(
            ILogger<ExtractService> logger,
            IExtractRepository extractRepository,
             IMapper mapper)
        {
            _logger = logger;
            _extractRepository = extractRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<AddExtractModelView>> AddAsync(AddExtractDto addExtractDto)
        {
            var validation = await new AddExtractDtoValidator()
                .ValidateAsync(addExtractDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<AddExtractModelView>(false, validation.Errors.First().ErrorMessage, new AddExtractModelView());

            var extractEntityMapper = _mapper.Map<ExtractEntity>(addExtractDto);

            var extractEntity = await _extractRepository.AddAsync(extractEntityMapper);

            if (!extractEntity.Success) return ResultsHelpers
                    .ReturnResulService<AddExtractModelView>(false, extractEntity.Message, _mapper.Map<AddExtractModelView>(extractEntityMapper));

            var addExtractModelView = _mapper.Map<AddExtractModelView>(extractEntity.Data);

            return ResultsHelpers
                .ReturnResulService<AddExtractModelView>(true, "Create Extract!", addExtractModelView);
        }
        public async Task<ResultService<GetExtractAllModelView>> GetAllAsync(PaginationDto paginationDto)
        {
            var validation = await new PaginationDtoValidator()
                .ValidateAsync(paginationDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<GetExtractAllModelView>(false, validation.Errors.First().ErrorMessage, new GetExtractAllModelView());

            var extractEntity = await _extractRepository
                .GetAllAsync(paginationDto);

            if (!extractEntity.Success) return ResultsHelpers
                    .ReturnResulService<GetExtractAllModelView>(false, extractEntity.Message, new GetExtractAllModelView());

            var getExtractAllModelView = new GetExtractAllModelView();

            foreach (var data in extractEntity.Data)
            {
                var getExtractModelView = _mapper.Map<GetExtractModelView>(data);

                getExtractAllModelView
                    .GetExtractModelViews
                    .Add(getExtractModelView);
            }

            return ResultsHelpers
                .ReturnResulService<GetExtractAllModelView>(true, "List Extract!", getExtractAllModelView);
        }
        public async Task<ResultService<GetExtractAllModelView>> GetByFiltersAsync(FilterExtractDto filterExtractDto, PaginationDto paginationDto)
        {
            var validation = await new PaginationDtoValidator()
                .ValidateAsync(paginationDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<GetExtractAllModelView>(false, validation.Errors.First().ErrorMessage, new GetExtractAllModelView());

            var extractEntityMapper = _mapper.Map<ExtractEntity>(filterExtractDto);

            var extractEntity = await _extractRepository
                .GetByFiltersAsync(extractEntityMapper, paginationDto);

            if (!extractEntity.Success) return ResultsHelpers
                    .ReturnResulService<GetExtractAllModelView>(false, extractEntity.Message, new GetExtractAllModelView());

            var getExtractAllModelView = new GetExtractAllModelView();

            foreach (var data in extractEntity.Data)
            {
                var getCustomerModelView = _mapper.Map<GetExtractModelView>(data);

                getExtractAllModelView
                    .GetExtractModelViews
                    .Add(getCustomerModelView);
            }

            return ResultsHelpers
                .ReturnResulService<GetExtractAllModelView>(true, "List Extract!", getExtractAllModelView);
        }
        public async Task<ResultService<UpdateExtractModelView>> UpdateAsync(UpdateExtractDto updateExtractDto)
        {
            var validation = await new UpdateExtractDtoValidator().ValidateAsync(updateExtractDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<UpdateExtractModelView>(false, validation.Errors.First().ErrorMessage, new UpdateExtractModelView());

            var extractEntityMapper = _mapper.Map<ExtractEntity>(updateExtractDto);

            var extractEntity = await _extractRepository
                .UpdateAsync(extractEntityMapper);

            if (!extractEntity.Success) return ResultsHelpers
                    .ReturnResulService<UpdateExtractModelView>(false, extractEntity.Message, new UpdateExtractModelView());

            var updateExtractModelView = _mapper.Map<UpdateExtractModelView>(extractEntity.Data);

            return ResultsHelpers
                .ReturnResulService<UpdateExtractModelView>(true, "Disabled Extract!", updateExtractModelView);
        }
        public async Task<ResultService<DisabledExtractModelView>> UpdateDisabledAsync(DisabledExtractDto disabledExtractDto)
        {
            var validation = await new DisabledExtractDtoValidator().ValidateAsync(disabledExtractDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<DisabledExtractModelView>(false, validation.Errors.First().ErrorMessage, new DisabledExtractModelView());

            var extractEntityMapper = _mapper.Map<ExtractEntity>(disabledExtractDto);

            var extractEntity = await _extractRepository
                .UpdateAsync(extractEntityMapper);

            if (!extractEntity.Success) return ResultsHelpers
                    .ReturnResulService<DisabledExtractModelView>(false, extractEntity.Message, new DisabledExtractModelView());

            var disabledExtractModelView = _mapper.Map<DisabledExtractModelView>(extractEntity.Data);

            return ResultsHelpers
                .ReturnResulService<DisabledExtractModelView>(true, "Disabled Extract!", disabledExtractModelView);
        }
    }
}
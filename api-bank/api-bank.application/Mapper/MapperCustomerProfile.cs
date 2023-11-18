using api_bank.domain.Dtos.CustomerDto;
using api_bank.domain.Entities;
using api_bank.domain.ModelView.CustomerModelView;
using AutoMapper;

namespace api_bank.application.Mapper
{
    public class MapperCustomerProfile : Profile
    {
        public MapperCustomerProfile()
        {
            CreateMap<AddCustomerDto, CustomerEntity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => DateTime.Now))
                    .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                    .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<UpdateCustomerDto, CustomerEntity>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                   .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => DateTime.Now))
                   .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<FilterCustomerDto, CustomerEntity>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                   .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                   .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.LastName, opt => opt.Ignore())
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.BankEntityId, opt => opt.Ignore());

            CreateMap<DisabledCustomerDto, CustomerEntity>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                  .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                  .ForMember(dest => dest.DateDisabled, opt => opt.MapFrom(src => DateTime.Now))
                  .ForMember(dest => dest.Name, opt => opt.Ignore())
                  .ForMember(dest => dest.LastName, opt => opt.Ignore())
                  .ForMember(dest => dest.Email, opt => opt.Ignore())
                  .ForMember(dest => dest.BankEntityId, opt => opt.Ignore())
                  .ForMember(dest => dest.ExtractEntitys, opt => opt.Ignore());

            CreateMap<CustomerEntity, GetCustomerModelView>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId))
                  .ForMember(dest => dest.ExtractEntitys, opt => opt.MapFrom(src => src.ExtractEntitys));

            CreateMap<CustomerEntity, AddCustomerModelView>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId))
                  .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCreation));

            CreateMap<CustomerEntity, UpdateCustomerModelView>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId))
                 .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => src.DateUpdated));
        }
    }
}
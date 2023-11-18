using api_bank.domain.Dtos;
using api_bank.domain.Entities;
using api_bank.domain.Enums;
using api_bank.domain.ModelView.ExtractModelView;
using AutoMapper;

namespace api_bank.application.Mapper
{
    public class MapperExtractProfile : Profile
    {
        public MapperExtractProfile()
        {
            CreateMap<AddExtractDto, ExtractEntity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => DateTime.Now))
                    .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                    .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                    .ForMember(dest => dest.Describe, opt => opt.MapFrom(src => src.Describe))
                    .ForMember(dest => dest.Loose, opt => opt.MapFrom(src => src.Loose))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.EExtractType, opt => opt.MapFrom(src => EExtractType.VALID))
                    .ForMember(dest => dest.CustomerEntityId, opt => opt.MapFrom(src => src.CustomerEntityId))
                    .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<UpdateExtractDto, ExtractEntity>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                   .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => DateTime.Now))
                   .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                   .ForMember(dest => dest.Describe, opt => opt.MapFrom(src => src.Describe))
                   .ForMember(dest => dest.Loose, opt => opt.MapFrom(src => src.Loose))
                   .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                   .ForMember(dest => dest.EExtractType, opt => opt.MapFrom(src => src.EExtractType));

            CreateMap<FilterExtractDto, ExtractEntity>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                   .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                   .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                   .ForMember(dest => dest.Describe, opt => opt.MapFrom(src => src.Describe))
                   .ForMember(dest => dest.Loose, opt => opt.Ignore())
                   .ForMember(dest => dest.Price, opt => opt.Ignore())
                   .ForMember(dest => dest.EExtractType, opt => opt.Ignore())
                   .ForMember(dest => dest.CustomerEntityId, opt => opt.MapFrom(src => src.CustomerEntityId))
                   .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<DisabledExtractDto, ExtractEntity>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                   .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                   .ForMember(dest => dest.DateDisabled, opt => opt.MapFrom(src => DateTime.Now))
                   .ForMember(dest => dest.Describe, opt => opt.Ignore())
                   .ForMember(dest => dest.Loose, opt => opt.Ignore())
                   .ForMember(dest => dest.Price, opt => opt.Ignore())
                   .ForMember(dest => dest.EExtractType, opt => opt.Ignore())
                   .ForMember(dest => dest.CustomerEntityId, opt => opt.Ignore())
                   .ForMember(dest => dest.BankEntityId, opt => opt.Ignore());

            CreateMap<ExtractEntity, AddExtractModelView>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCreation))
                  .ForMember(dest => dest.Describe, opt => opt.MapFrom(src => src.Describe))
                  .ForMember(dest => dest.Loose, opt => opt.MapFrom(src => src.Loose))
                  .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                  .ForMember(dest => dest.EExtractType, opt => opt.MapFrom(src => src.EExtractType))
                  .ForMember(dest => dest.CustomerEntityId, opt => opt.MapFrom(src => src.CustomerEntityId))
                  .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<ExtractEntity, UpdateExtractModelView>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => src.DateUpdated))
                  .ForMember(dest => dest.Describe, opt => opt.MapFrom(src => src.Describe))
                  .ForMember(dest => dest.Loose, opt => opt.MapFrom(src => src.Loose))
                  .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                  .ForMember(dest => dest.EExtractType, opt => opt.MapFrom(src => src.EExtractType))
                  .ForMember(dest => dest.CustomerEntityId, opt => opt.MapFrom(src => src.CustomerEntityId))
                  .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<ExtractEntity, GetExtractModelView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCreation))
                .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => src.DateUpdated))
                .ForMember(dest => dest.Describe, opt => opt.MapFrom(src => src.Describe))
                .ForMember(dest => dest.Loose, opt => opt.MapFrom(src => src.Loose))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.EExtractType, opt => opt.MapFrom(src => src.EExtractType))
                .ForMember(dest => dest.CustomerEntityId, opt => opt.MapFrom(src => src.CustomerEntityId))
                .ForMember(dest => dest.BankEntityId, opt => opt.MapFrom(src => src.BankEntityId));

            CreateMap<ExtractEntity, DisabledExtractModelView>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.DateDisabled, opt => opt.MapFrom(src => src.DateDisabled));
        }
    }
}
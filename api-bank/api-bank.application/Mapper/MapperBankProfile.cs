using api_bank.domain.Dtos.BankDto;
using api_bank.domain.Entities;
using api_bank.domain.ModelView.BankModelView;
using AutoMapper;

namespace api_bank.application.Mapper
{
    public class MapperBankProfile : Profile
    {
        public MapperBankProfile()
        {
            CreateMap<AddBankDto, BankEntity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => DateTime.Now))
                    .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                    .ForMember(dest => dest.DateDisabled, opt => opt.Ignore())
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number));

            CreateMap<BankEntity, AddBankModelView>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCreation))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number));

            CreateMap<BankEntity, GetBankModelView>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => src.DateCreation))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                 .ForMember(dest => dest.ExtractEntitys, opt => opt.MapFrom(src => src.ExtractEntitys))
                 .ForMember(dest => dest.CustomerEntitys, opt => opt.MapFrom(src => src.CustomerEntitys));
        }
    }
}
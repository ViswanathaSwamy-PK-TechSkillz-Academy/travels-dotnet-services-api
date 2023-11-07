using AutoMapper;
using Countries.Data.Dtos;
using Countries.Data.Entities;

namespace Countries.Repositories.Mappers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        _ = CreateMap<CreateCountryInfoDto, CountryInfo>().ReverseMap();

        _ = CreateMap<CountryInfo, CountryInfoDto>().ReverseMap();
    }
}
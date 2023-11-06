using Countries.Data.Dtos;

namespace Countries.ApplicationCore.Interfaces;

public interface ICountriesBusiness
{
    Task<CountryInfoDto> AddCountry(CreateCountryInfoDto createCountryInfoDto);

    Task<IReadOnlyCollection<CountryInfoDto>> GetAllCountries();
}

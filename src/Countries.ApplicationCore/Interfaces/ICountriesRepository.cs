using Countries.Data.Dtos;

namespace Countries.ApplicationCore.Interfaces;

public interface ICountriesRepository
{
    Task<CountryInfoDto> AddCountry(CreateCountryInfoDto createCountryInfoDto);

    Task<IReadOnlyCollection<CountryInfoDto>> GetAllCountries();
}

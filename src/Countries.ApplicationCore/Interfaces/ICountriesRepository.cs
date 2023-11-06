using Countries.Data.Dtos;
using Countries.Data.Entities;

namespace Countries.ApplicationCore.Interfaces;

public interface ICountriesRepository
{
    Task<CountryInfoDto> AddCountry(CreateCountryInfoDto createCountryInfoDto);

    Task<IReadOnlyCollection<CountryInfo>> GetAllCountries();
}

using Countries.ApplicationCore.Interfaces;
using Countries.Data.Dtos;
using Microsoft.Extensions.Logging;

namespace Countries.Business;

public class CountriesBusiness(ICountriesRepository countriesRepository, ILogger<CountriesBusiness> logger) : ICountriesBusiness
{
    private readonly ICountriesRepository _countriesRepository = countriesRepository ?? throw new ArgumentNullException(nameof(countriesRepository));
    private readonly ILogger<CountriesBusiness> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<CountryInfoDto> AddCountry(CreateCountryInfoDto createCountryInfoDto)
    {
        _logger.LogInformation($"Starting CountriesBusiness::AddCountry()");

        return await _countriesRepository.AddCountry(createCountryInfoDto);
    }

    public async Task<IReadOnlyCollection<CountryInfoDto>> GetAllCountries()
    {
        _logger.LogInformation($"Starting CountriesBusiness::GetAllCountries()");

        return await _countriesRepository.GetAllCountries();
    }
}
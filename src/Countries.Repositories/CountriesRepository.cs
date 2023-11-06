using AutoMapper;
using Countries.ApplicationCore.Interfaces;
using Countries.Data.Dtos;
using Countries.Data.Entities;
using Countries.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Countries.Repositories;

public class CountriesRepository(CountriesDbContext countriesDbContext, ILogger<CountriesRepository> logger, IMapper mapper) : ICountriesRepository
{
    private readonly CountriesDbContext _countriesDbContext = countriesDbContext ?? throw new ArgumentNullException(nameof(countriesDbContext));
    private readonly ILogger<CountriesRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IReadOnlyCollection<CreateCountryInfoDto>> GetAllCountries()
    {
        _logger.LogInformation($"Starting CountriesRepository::GetAllCountries()");

        return _mapper.Map<List<CreateCountryInfoDto>>(await _countriesDbContext.CountriesInfo.ToListAsync());
    }

    public async Task<CountryInfoDto> AddCountry(CreateCountryInfoDto createCountryInfoDto)
    {
        _logger.LogInformation($"Starting CountriesRepository::AddCountry()");

        var countryInfoEntity = _mapper.Map<CountryInfo>(createCountryInfoDto);

        _countriesDbContext.CountriesInfo.Add(countryInfoEntity);
        await _countriesDbContext.SaveChangesAsync();

        return _mapper.Map<CountryInfoDto>(countryInfoEntity);
    }

}
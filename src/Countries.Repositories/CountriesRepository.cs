using Countries.ApplicationCore.Interfaces;
using Countries.Data.Entities;
using Countries.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Countries.Repositories;

public class CountriesRepository(CountriesDbContext countriesDbContext, ILogger<CountriesRepository> logger) : ICountriesRepository
{
    private readonly CountriesDbContext _countriesDbContext = countriesDbContext ?? throw new ArgumentNullException(nameof(countriesDbContext));
    private readonly ILogger<CountriesRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<IReadOnlyCollection<CountryInfo>> GetAllCountries()
    {
        _logger.LogInformation($"Starting CountriesRepository::GetAllCountries()");

        return await _countriesDbContext.CountriesInfo.ToListAsync();
    }
}
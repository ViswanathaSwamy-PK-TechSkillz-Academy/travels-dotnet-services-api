using Countries.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Countries.Persistence;

public class CountriesDbContext(DbContextOptions<CountriesDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<CountryInfo> CountriesInfo => Set<CountryInfo>();
}
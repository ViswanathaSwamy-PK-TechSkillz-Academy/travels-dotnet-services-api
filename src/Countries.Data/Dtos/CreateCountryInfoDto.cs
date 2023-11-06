namespace Countries.Data.Entities;

public record CreateCountryInfoDto
{
    public string? CountryName { get; set; }

    public string? CapitalState { get; set; }

    public string? NationalBird { get; set; }

    public long CountryPopulation { get; set; }
}
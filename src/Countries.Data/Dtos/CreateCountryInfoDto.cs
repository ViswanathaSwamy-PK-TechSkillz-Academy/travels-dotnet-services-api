using System.Text.Json.Serialization;

namespace Countries.Data.Dtos;

public record CreateCountryInfoDto
{
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    [JsonPropertyName("capital_state")]
    public string? CapitalState { get; set; }

    [JsonPropertyName("national_bird")]
    public string? NationalBird { get; set; }

    [JsonPropertyName("country_population")]
    public long CountryPopulation { get; set; }
}
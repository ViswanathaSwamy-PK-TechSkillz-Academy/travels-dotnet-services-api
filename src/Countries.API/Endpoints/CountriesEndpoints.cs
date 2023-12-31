﻿using Countries.ApplicationCore.Interfaces;
using Countries.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using static Countries.ApplicationCore.Common.Constants;

namespace Countries.API.Endpoints;

public static class CountriesEndpoints
{

    public static void MapCountriesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(CountriesRoutes.Prefix).WithTags(nameof(CreateCountryInfoDto));

        _ = group.MapPost(CountriesRoutes.Root, async ([FromBody] CreateCountryInfoDto createCountryInfoDto, [FromServices] ICountriesBusiness countriesBusiness) =>
        {
            return Results.Ok(await countriesBusiness.AddCountry(createCountryInfoDto));

        })
          .AllowAnonymous()
          .WithName("AddCountry")
          .Produces<CountryInfoDto>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status500InternalServerError)
          .WithOpenApi();

        _ = group.MapGet(CountriesRoutes.Root, async ([FromServices] ICountriesBusiness countriesBusiness) =>
        {
            return Results.Ok(await countriesBusiness.GetAllCountries());

        })
          .AllowAnonymous()
          .WithName("GetAllCountries")
          .Produces<IReadOnlyCollection<CountryInfoDto>>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status500InternalServerError)
          .WithOpenApi();
    }

}

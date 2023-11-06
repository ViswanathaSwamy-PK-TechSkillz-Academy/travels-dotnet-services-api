﻿using Countries.Data.Entities;

namespace Countries.ApplicationCore.Interfaces;

public interface ICountriesRepository
{
    Task<IReadOnlyCollection<CreateCountryInfoDto>> GetAllCountries();
}

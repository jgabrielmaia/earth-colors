namespace EarthColors.Infrastructure.Repository;

using EarthColors.Domain.Entities;
using EarthColors.Domain.Interfaces;

public class CountriesRepository : ICountriesRepository
{
    private readonly Dictionary<Guid, Country> _countries = new();

    public Country? GetById(Guid id) 
    {
        if(_countries.TryGetValue(id, out var country)) 
        {
            return country;
        };

        return null;
    }

    public IEnumerable<Country> GetAll() => _countries.Values.ToList();

    public void Delete(Guid id) => _countries.Remove(id);

    public void Create(Country country)
    {
        if(country is null)
        {
            return;
        }

        _countries[country.Id] = country;
    }
    public void Update(Country country)
    {
        var existingCountry = GetById(country.Id);
        if(existingCountry is null)
        {
            return;
        }

        _countries[country.Id] = country;
    }
}
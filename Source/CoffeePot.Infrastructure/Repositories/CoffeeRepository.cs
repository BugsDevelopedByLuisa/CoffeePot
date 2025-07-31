using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoffeePot.Domain.Entities;
using CoffeePot.Domain.Enumerations;
using CoffeePot.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeePot.Infrastructure.Repositories;

public class CoffeeRepository : ICoffeeRepository
{
  private readonly ApplicationContext _applicationContext;
  private readonly ILogger<CoffeeRepository> _logger;

  public CoffeeRepository(ApplicationContext applicationContext, ILogger<CoffeeRepository> logger)
  {
    _applicationContext = applicationContext;
    _logger = logger;
  }

  public async Task<IEnumerable<Coffee>> GetAllCoffeeAsync(CancellationToken cancellationToken)
  {
    return (await _applicationContext.Coffees.Where(x => x.Status != Status.Deleted).ToListAsync(cancellationToken));
  }

  public async Task<Coffee> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken)
  {
    var loadedCoffee = await _applicationContext.Coffees.Where(x => x.Id == id && x.Status != Status.Deleted)
      .FirstOrDefaultAsync(cancellationToken);

    if (loadedCoffee == null)
    {
      _logger.LogInformation("No coffee with id {0} was found!", id);
      throw new ArgumentException("Not found");
    }

    return loadedCoffee;
  }

  public async Task<Coffee> CreateCoffeeAsync(Coffee coffee, CancellationToken cancellationToken)
  {
    try
    {
      _applicationContext.Coffees.Add(coffee);
      await _applicationContext.SaveChangesAsync(cancellationToken);
      return coffee;
    }
    catch (Exception e)
    {
      _logger.LogError(e.Message);
      throw;
    }
  }

  public async Task<Coffee> UpdateCoffeeByIdAsync(int id, Coffee coffee, CancellationToken cancellationToken)
  {
    var loadedCoffee = await _applicationContext.Coffees.Where(x => x.Id == id && x.Status != Status.Deleted)
      .FirstOrDefaultAsync(cancellationToken);

    if (loadedCoffee == null)
    {
      _logger.LogInformation("No coffee with id {0} was found!", id);
      throw new ArgumentException("Not found");
    }

    loadedCoffee.Brand = coffee.Brand;
    loadedCoffee.Variety = coffee.Variety;
    loadedCoffee.PricePerUnit = coffee.PricePerUnit;
    loadedCoffee.ChangeDate = DateTime.Now;

    try
    {
      await _applicationContext.SaveChangesAsync(cancellationToken);
      return loadedCoffee;
    }
    catch (Exception e)
    {
      _logger.LogError(e.Message);
      throw;
    }
  }

  public async Task<Coffee> DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken)
  {
    var loadedCoffee = await _applicationContext.Coffees.Where(x => x.Id == id && x.Status != Status.Deleted)
      .FirstOrDefaultAsync(cancellationToken);

    if (loadedCoffee == null)
    {
      _logger.LogInformation("No coffee with id {0} was found!", id);
      throw new ArgumentException("Not found");
    }

    loadedCoffee.Status = Status.Deleted;
    loadedCoffee.ChangeDate = DateTime.Now;

    try
    {
      await _applicationContext.SaveChangesAsync(cancellationToken);
      return loadedCoffee;
    }
    catch (Exception e)
    {
      _logger.LogError(e.Message);
      throw;
    }
  }
}

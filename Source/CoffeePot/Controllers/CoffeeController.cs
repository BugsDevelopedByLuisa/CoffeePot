using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoffeePot.Domain.Entities;
using CoffeePot.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePot.Controllers;

[Route("coffee")]
public class CoffeeController : Controller, ICoffeeRepository
{
  private readonly ICoffeeRepository _coffeeRepository;

  public CoffeeController(ICoffeeRepository coffeeRepository)
  {
    _coffeeRepository = coffeeRepository;
  }

  /// <summary>
  ///   Returns a list with all coffees.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpGet]
  public async Task<IEnumerable<Coffee>> GetAllCoffeeAsync(CancellationToken cancellationToken)
  {
    return await _coffeeRepository.GetAllCoffeeAsync(cancellationToken);
  }

  /// <summary>
  ///   Returns a coffee based on its id.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpGet("{id:int}")]
  public async Task<Coffee> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken)
  {
    return await _coffeeRepository.GetCoffeeByIdAsync(id, cancellationToken);
  }

  /// <summary>
  ///   Creates a new coffee.
  /// </summary>
  /// <param name="coffee">The coffee.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpPost]
  public async Task<Coffee> CreateCoffeeAsync([FromBody] Coffee coffee, CancellationToken cancellationToken)
  {
    return await _coffeeRepository.CreateCoffeeAsync(coffee, cancellationToken);
  }

  /// <summary>
  ///   Updates a coffee based on its id.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <param name="coffee">The coffee.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpPut("{id:int}")]
  public async Task<Coffee> UpdateCoffeeByIdAsync(int id, [FromBody] Coffee coffee, CancellationToken cancellationToken)
  {
    return await _coffeeRepository.UpdateCoffeeByIdAsync(id, coffee, cancellationToken);
  }

  /// <summary>
  ///   Deletes a coffee based on its id.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpDelete("{id:int}")]
  public async Task<Coffee> DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken)
  {
    return await _coffeeRepository.DeleteCoffeeByIdAsync(id, cancellationToken);
  }
}

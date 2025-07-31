using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoffeePot.Domain.Entities;

namespace CoffeePot.Domain.Repositories;

public interface ICoffeeRepository
{
  Task<IEnumerable<Coffee>> GetAllCoffeeAsync(CancellationToken cancellationToken);
  Task<Coffee> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken);
  Task<Coffee> CreateCoffeeAsync(Coffee coffee, CancellationToken cancellationToken);
  Task<Coffee> UpdateCoffeeByIdAsync(int id, Coffee coffee, CancellationToken cancellationToken);
  Task<Coffee> DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken);
}

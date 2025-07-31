using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoffeePot.Domain.Entities;

namespace CoffeePot.Domain.Repositories;

public interface IPersonRepository
{
  Task<IEnumerable<Person>> GetAllPersonsAsync(CancellationToken cancellationToken);
  Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken);
  Task<Person> CreatePersonAsync(Person person, CancellationToken cancellationToken);
  Task<Person> UpdatePersonByIdAsync(int id, Person person, CancellationToken cancellationToken);
  Task<Person> DeletePersonByIdAsync(int id, CancellationToken cancellationToken);
}

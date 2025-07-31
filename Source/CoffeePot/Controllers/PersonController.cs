using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoffeePot.Domain.Entities;
using CoffeePot.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePot.Controllers;

[Route("person")]
public class PersonController : Controller, IPersonRepository
{
  private readonly IPersonRepository _personRepository;

  public PersonController(IPersonRepository personRepository)
  {
    _personRepository = personRepository;
  }

  /// <summary>
  ///   Returns a list with all persons.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpGet]
  public async Task<IEnumerable<Person>> GetAllPersonsAsync(CancellationToken cancellationToken)
  {
    return await _personRepository.GetAllPersonsAsync(cancellationToken);
  }

  /// <summary>
  ///   Returns a person based on its id.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpGet("{id:int}")]
  public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
  {
    return await _personRepository.GetPersonByIdAsync(id, cancellationToken);
  }

  /// <summary>
  ///   Creates a new person.
  /// </summary>
  /// <param name="person">The person.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpPost]
  public async Task<Person> CreatePersonAsync([FromBody] Person person, CancellationToken cancellationToken)
  {
    return await _personRepository.CreatePersonAsync(person, cancellationToken);
  }

  /// <summary>
  ///   Updates a person based on its id.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <param name="person">The person.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpPut("{id:int}")]
  public async Task<Person> UpdatePersonByIdAsync(int id, [FromBody] Person person, CancellationToken cancellationToken)
  {
    return await _personRepository.UpdatePersonByIdAsync(id, person, cancellationToken);
  }

  /// <summary>
  ///   Deletes a person based on its id.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  [HttpDelete("{id:int}")]
  public async Task<Person> DeletePersonByIdAsync(int id, CancellationToken cancellationToken)
  {
    return await _personRepository.DeletePersonByIdAsync(id, cancellationToken);
  }
}

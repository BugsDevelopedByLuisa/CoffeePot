using CoffeePot.Domain.Common;

namespace CoffeePot.Domain.Entities;

public class Person : BaseEntity
{
  public string Forename { get; set; }
  public string Surname { get; set; }
}

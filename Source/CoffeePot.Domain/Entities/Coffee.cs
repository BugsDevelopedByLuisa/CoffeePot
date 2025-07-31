using CoffeePot.Domain.Common;

namespace CoffeePot.Domain.Entities;

public class Coffee : BaseEntity
{
  public string Brand { get; set; }
  public string Variety { get; set; }
  public double PricePerUnit { get; set; }
}

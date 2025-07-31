using CoffeePot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeePot.Infrastructure;

public class ApplicationContext : DbContext
{
  public DbSet<Coffee> Coffees { get; set; }
}

using Microsoft.AspNetCore.Builder;

namespace CoffeePot;

public static class Program
{
  public static void Main()
  {
    var startup = new Startup();
    var app = startup.BuildWebApplication();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", () => "Hello World!");
    app.Run();
  }
}

using System.Reflection;

namespace ReportingTester.Apis;

public static class ApiExtensions
{
  public static void AddApis(this IServiceCollection svcs)
  {
    var apiGroups = Assembly.GetExecutingAssembly()
     .GetTypes()
     .Where(t => t.GetInterfaces().Contains(typeof(IApiGroup)))
     .ToList();

    foreach (var group in apiGroups)
    {
      svcs.AddTransient(typeof(IApiGroup), group);
    }
  }

  public static void MapApis(this WebApplication app)
  {
    var scope = app.Services.CreateScope();

    var groups = scope.ServiceProvider.GetServices<IApiGroup>();
    foreach (var group in groups)
    {
      group.Register(app);
    }

  }
}

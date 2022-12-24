using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportingTester.Data;
using ReportingTester.Data.Entities;

namespace ReportingTester.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;
    private readonly StoreDbContext _ctx;

    public IndexModel(ILogger<IndexModel> logger, StoreDbContext ctx)
    {
      _logger = logger;
      _ctx = ctx;
    }

    public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

    public void OnGet()
    {
      Customers = _ctx.Customers.ToList();
    }
  }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReportingTester.Data;
using ReportingTester.Data.Entities;
using ReportingTester.Models;

namespace ReportingTester.Apis;

public class CustomerGroup : IApiGroup
{

  private readonly ILogger<CustomerGroup> _logger;
  private readonly StoreDbContext _context;
  private readonly IMapper _mapper;

  public CustomerGroup(ILogger<CustomerGroup> logger,
    StoreDbContext context,
    IMapper mapper)
  {
    _logger = logger;
    _context = context;
    _mapper = mapper;
  }

  public void Register(WebApplication app)
  {
    var group = app.MapGroup("/api/customers");

    group.MapGet("", GetAll);
    group.MapGet("{id:int}", GetOne);
  }

  private async Task<IResult> GetAll(bool includeOrders = false)
  {
    IEnumerable<Customer> customers;

    if (includeOrders)
    {
      customers = await _context.Customers.OrderBy(c => c.LastName)
                                .ThenBy(c => c.FirstName)
                                .Include(c => c.Orders)
                                .ThenInclude(o => o.OrderItems)
                                .ThenInclude(i => i.Product)
                                .ToListAsync();
    }
    else
    {
      customers = await _context.Customers.OrderBy(c => c.LastName)
                                .ThenBy(c => c.FirstName)
                                .ToListAsync();
    }

    var result = _mapper.Map<IEnumerable<CustomerModel>>(customers);

    return Results.Ok(result);
  }

  private async Task<IResult> GetOne(int id)
  {
    var cust = await _context.Customers.Where(c => c.CustomerId == id)
      .FirstOrDefaultAsync();

    if (cust is null) return Results.NotFound();

    return Results.Ok(_mapper.Map<CustomerModel>(cust));
  }
}
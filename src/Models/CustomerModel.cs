namespace ReportingTester.Models;

public class CustomerModel
{
  public int CustomerId { get; set; }

  public string FirstName { get; set; } = null!;

  public string LastName { get; set; } = null!;

  public string? Phone { get; set; }

  public string Email { get; set; } = null!;

  public string? Street { get; set; }

  public string? City { get; set; }

  public string? State { get; set; }

  public string? ZipCode { get; set; }

  public virtual ICollection<OrderModel> Orders { get; } = new List<OrderModel>();
}

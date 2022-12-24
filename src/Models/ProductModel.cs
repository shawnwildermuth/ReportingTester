using ReportingTester.Data.Entities;

namespace ReportingTester.Models;

public class ProductModel 
{
  public int ProductId { get; set; }

  public string ProductName { get; set; } = null!;

  public int BrandId { get; set; }

  public int CategoryId { get; set; }

  public short ModelYear { get; set; }

  public decimal ListPrice { get; set; }

  public virtual BrandModel Brand { get; set; } = null!;

  public virtual CategoryModel Category { get; set; } = null!;

}
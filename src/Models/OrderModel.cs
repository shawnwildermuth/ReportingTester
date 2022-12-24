using ReportingTester.Data.Entities;

namespace ReportingTester.Models;

public class OrderModel
{
  public int OrderId { get; set; }

  public int? CustomerId { get; set; }

  public byte OrderStatus { get; set; }

  public DateTime OrderDate { get; set; }

  public DateTime RequiredDate { get; set; }

  public DateTime? ShippedDate { get; set; }

  public int StoreId { get; set; }

  public int StaffId { get; set; }

  public virtual ICollection<OrderItemModel> OrderItems { get; } = new List<OrderItemModel>();

  public virtual StaffModel Staff { get; set; } = null!;

  public virtual StoreModel Store { get; set; } = null!;
}
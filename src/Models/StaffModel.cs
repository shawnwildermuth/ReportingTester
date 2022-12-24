using ReportingTester.Data.Entities;

namespace ReportingTester.Models
{
  public class StaffModel
  {
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public byte Active { get; set; }

  }
}
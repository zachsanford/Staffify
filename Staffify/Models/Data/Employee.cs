using System.ComponentModel.DataAnnotations;
namespace Staffify.Models.Data;

public class Employee
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Name is too long.")]
    public string Name { get; set; }
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }
}

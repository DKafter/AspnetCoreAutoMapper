using System.ComponentModel.DataAnnotations;

namespace dotnetautomapper.Models.Customer;

public class CustomerBaseModel
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Email { get; set; } = string.Empty;
}
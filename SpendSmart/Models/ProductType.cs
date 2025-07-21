using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models;

public class ProductType
{
    public int Id { get; set; }
    
    [Required][MaxLength(20)]
    public required string ProductTypeName { get; set; }
}
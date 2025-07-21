using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendSmart.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than zero")]
    public decimal Value { get; set; }

    [Required]
    [MaxLength(50)]
    public string Description { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Please select a product type")]
    
    public int ProductTypeId { get; set; }
    
    public ProductType? ProductType { get; set; }
    
    public int SubTypeId { get; set; }
    
    public SubType? SubType { get; set; }
}
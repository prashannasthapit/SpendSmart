using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models;

public class SubType
{
    public int Id { get; set; }

    [Required][MaxLength(30)]
    public required string SubTypeName { get; set; }

    public int ProductTypeId { get; set; }

    public ProductType? ProductType { get; set; }
}
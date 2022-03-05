using System.ComponentModel.DataAnnotations;

namespace Shop.ApplicationCore.DTOs;

public class CreateProductRequest
{
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public double Price { get; set; }
}

public class UpdateProductRequest : CreateProductRequest
{
    [Required]
    [Range(0, 100)]
    public int Stock { get; set; }
}

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}

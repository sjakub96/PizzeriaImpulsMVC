using System.ComponentModel.DataAnnotations;

namespace PizzeriaImpulsMVC.Domain.Models;

public class ShoppingCart
{
    [Key]
    public int RecordId { get; set; }
    public int CartId { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public int ProductCount { get; set; }
    public string ProductType { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
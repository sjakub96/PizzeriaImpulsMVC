namespace PizzeriaImpulsMVC.Domain.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal? ProductSize { get; set; }
    public int ProductCount { get; set; }
    public string ProductType { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}
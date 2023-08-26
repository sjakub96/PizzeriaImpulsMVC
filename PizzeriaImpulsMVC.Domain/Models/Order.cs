namespace PizzeriaImpulsMVC.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HomeNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }

}
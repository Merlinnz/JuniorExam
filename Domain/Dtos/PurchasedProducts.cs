using Domain.Entities;

namespace Domain.Dtos;

public class PurchasedProducts
{
    public int ProductId { get; set; }
    public Category Category { get; set; }
    public ProductCredit ProductCredit { get; set; }
    public InstallementInterest InstallementInterest { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public double ProductPrice { get; set; }
    //public double ProductPricePerMonth { get; set; }

    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}

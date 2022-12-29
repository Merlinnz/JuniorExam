using Domain.Entities;

namespace Domain.Dtos;

public class GetProductDto
{
    public int ProductId { get; set; }
    public Category Category { get; set; }
    public ProductCredit ProductCredit { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public double ProductPrice { get; set; }
    //public double ProductPricePerMonth { get; set; }
    public int UserId { get; set; }
}

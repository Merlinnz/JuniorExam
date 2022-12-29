using Domain.Entities;

namespace Domain.Dtos;

public class GetProductCreditDto
{
    public Category Category { get; set; }
    public double productPrice { get; set; }
    public ProductCredit installmentPeriod { get; set; }
}

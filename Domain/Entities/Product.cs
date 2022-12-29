using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public Category Category { get; set; }
    public ProductCredit ProductCredit { get; set; }
    public InstallementInterest InstallmentInterest { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public double ProductPrice { get; set; }

    // References
    public List<User> Users { get; set; }
}

public enum ProductCredit
{
    // Between 3-9 months SmartPhone,  3-12 months Computer, 3-18 months TV
    ThreeMonth = 3,
    SixMonth = 6,
    NineMonth = 9,
    TwelveMonth = 12,
    EighteenMonth = 18,
    TwentyMonth = 24
}

public enum InstallementInterest
{
    SmartPhone = 37,
    Computer = 4,
    Television = 5
}

public enum Category
{
    SmartPhone = 1,
    Computer,
    Television
}

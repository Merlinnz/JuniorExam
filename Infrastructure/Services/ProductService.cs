using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ProductService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetProductDto>>> GetProducts()
    {
        var list = _mapper.Map<List<GetProductDto>>( await _context.Products.ToListAsync());
        return new Response<List<GetProductDto>>(list);
    }

    public async Task<Response<AddProductDto>> AddProduct(AddProductDto product)
    {
        var newProduct = _mapper.Map<Product>(product);
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
        return new Response<AddProductDto>(product);
    }

    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto product)
    {
        var find = await _context.Products.FindAsync(product.ProductId);
        find.ProductName = product.ProductName;
        find.Category = product.Category;
        find.ProductCredit = product.ProductCredit;
        find.Description = product.Description;
        find.ProductPrice = product.ProductPrice;

        await _context.SaveChangesAsync();
        return new Response<AddProductDto>(product);
    }

    public async Task<Response<string>> DeleteProduct(int id)
    {
        var find = await _context.Products.FindAsync(id);
        _context.Products.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Product has been Deleted");
    }

    public double ProductCredits(Category productCategory, double productPrice, ProductCredit installementPeriod)
    {
        if (ProductCredit.NineMonth == installementPeriod && Category.SmartPhone == productCategory )
        {
            return productPrice ;
        }
        if (ProductCredit.TwelveMonth == installementPeriod && Category.SmartPhone == productCategory )
        {
            return (productPrice + (productPrice * 3 / 100));
        }
        if (ProductCredit.EighteenMonth == installementPeriod && Category.SmartPhone == productCategory )
        {
            return (productPrice + (productPrice * 32 / 100)) ;
        }
        if (ProductCredit.TwentyMonth == installementPeriod && Category.SmartPhone == productCategory)
        {
            return (productPrice + (productPrice * 37 / 100));
        }
        // Per Month  in this statement it shows product prices per month only 3, 6 and 9 months And in 12-18-24 it shows how product costs if you buy it with credit 
        // Example if product costs 4500$ and you want buy it with credit card in 12 month then your product price will be 4635

        if (ProductCredit.ThreeMonth == installementPeriod && Category.SmartPhone == productCategory )
        {
            return productPrice / ((double)installementPeriod);
        }
        if (ProductCredit.SixMonth == installementPeriod && Category.SmartPhone == productCategory)
        {
            return productPrice / ((double)installementPeriod );
        }
        if (ProductCredit.NineMonth == installementPeriod && Category.SmartPhone == productCategory)
        {
            return productPrice / ((double)installementPeriod );
        }

        //************************************************************************************************
        if (ProductCredit.NineMonth == installementPeriod && Category.Computer == productCategory )
        {
            return productPrice;
        }
        if (ProductCredit.TwelveMonth == installementPeriod && Category.Computer == productCategory )
        {
            return (productPrice + (productPrice * 4 / 100)) ;
        }
        if (ProductCredit.TwentyMonth == installementPeriod && Category.Computer == productCategory ){
            return (productPrice + (productPrice * 8 / 100));
        }
        // Per Month  in this statement it shows product prices per month only 3, 6 and 9 months And in 12-18-24 it shows how product costs if you buy it with credit 
        // Example if product costs 4500$ and you want buy it with credit card in 12 month then your product price will be 4680

        if (ProductCredit.ThreeMonth == installementPeriod && Category.Computer == productCategory )
        {
            return productPrice / ((double)installementPeriod);
        }
        if (ProductCredit.SixMonth == installementPeriod && Category.Computer == productCategory)
        {
            return productPrice / ((double)installementPeriod );
        }
        if (ProductCredit.NineMonth == installementPeriod && Category.Computer == productCategory)
        {
            return productPrice / ((double)installementPeriod );
        }

        //************************************************************************************************
        
        if (ProductCredit.TwelveMonth == installementPeriod && Category.Television == productCategory )
        {
            return (productPrice + (productPrice * 5 / 100));
        }
        if (ProductCredit.EighteenMonth == installementPeriod && Category.Television == productCategory )
        {
            return (productPrice + (productPrice * 10 / 100));
        }
        if (ProductCredit.TwentyMonth == installementPeriod && Category.Television == productCategory )
        {
            return (productPrice + (productPrice * 15 / 100));
        }
        // Per Month  in this statement it shows product prices per month only 3, 6 and 9 months And in 12-18-24 it shows how product costs if you buy it with credit 
        // Example if product costs 4500$ and you want buy it with credit card in 12 month then your product price will be 4725
    
        if (ProductCredit.ThreeMonth == installementPeriod && Category.Television == productCategory )
        {
            return productPrice / ((double)installementPeriod);
        }
        if (ProductCredit.SixMonth == installementPeriod && Category.Television == productCategory)
        {
            return productPrice / ((double)installementPeriod );
        }
        if (ProductCredit.NineMonth == installementPeriod && Category.Television == productCategory)
        {
            return productPrice / ((double)installementPeriod );
        }
        return productPrice;
    }
}

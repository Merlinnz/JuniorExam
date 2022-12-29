using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly ProductService _productService;
    public UserService(DataContext context, IMapper mapper, ProductService productService)
    {
        _context = context;
        _mapper = mapper;
        _productService = productService;
    }

    public async Task<Response<List<GetUserDto>>> GetUsers()
    {
        var list = _mapper.Map<List<GetUserDto>>( await _context.Users.ToListAsync());
        return new Response<List<GetUserDto>>(list);
    }

    public async Task<Response<AddUserDto>> AddUser(AddUserDto user)
    {
        var newUser = _mapper.Map<User>(user);
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return new Response<AddUserDto>(user);
    }
    public async Task<Response<AddUserDto>> UpdateUser(AddUserDto user)
    {
        var find = await _context.Users.FindAsync(user.UserId);
        find.FirstName = user.FirstName;
        find.LastName = user.LastName;
        find.Email = user.Email;
        find.Phone = user.Phone;
        find.Address = user.Address;
    
        await _context.SaveChangesAsync();
        return new Response<AddUserDto>(user);
    }

    public async Task<Response<string>> DeleteUser(int id)
    {
        var find = await _context.Users.FindAsync(id);
        _context.Users.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("User has been Deleted");
    }

    // Purchased Product joined User and Product tables

    public async Task<Response<List<PurchasedProducts>>> GetPurchasedProducts()
    {
        var join = await (from u in _context.Users
        join p in _context.Products on u.ProductId equals p.ProductId
        select new PurchasedProducts()
        {
            UserId = u.UserId,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Phone = u.Phone,
            Address = u.Address,
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Description = p.Description,
            ProductPrice = p.ProductPrice,
            Category = p.Category,
            ProductCredit = p.ProductCredit
        }).ToListAsync();
        return new Response<List<PurchasedProducts>>(join);
    }

    public async Task<Response<PurchasedProducts>> Get(GetProductCreditDto credit)
    {
        var install = _productService.ProductCredits(credit.Category, credit.productPrice, credit.installmentPeriod);
        var list = await (from t in _context.Users
        join r in _context.Products on t.ProductId equals r.ProductId
        select new PurchasedProducts()
        {
            UserId = t.UserId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            Address = t.Address,
            Email = t.Email,
            Phone = t.Phone,
            ProductId = r.ProductId,
            ProductName = r.ProductName,
            Description = r.Description,
            //Category = credit.Category,
            ProductPrice = _productService.ProductCredits(credit.Category, credit.productPrice, credit.installmentPeriod),
            // ProductCredit = credit.installmentPeriod,
            // //InstallementInterest = credit.installementInterest

            
        }).FirstOrDefaultAsync();
        //credit.ProductPricePerMonth = Math.Round(credit.productPrice/(double)credit.installmentPeriod, 2);

        await _context.SaveChangesAsync();
        return new Response<PurchasedProducts>(list);
    }
}
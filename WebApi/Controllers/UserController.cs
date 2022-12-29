using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
namespace WebApi.Controllers;

public class UserController
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUsers")]
    public async Task<Response<List<GetUserDto>>> GetUsers()
    {
        return await _userService.GetUsers();
    }

    [HttpPost("CreateUser")]
    public async Task<Response<AddUserDto>> AddUser(AddUserDto user)
    {
        return await _userService.AddUser(user);
    }

    [HttpPut("UpdateUser")]
    public async Task<Response<AddUserDto>> UpdateUser(AddUserDto user)
    {
        return await _userService.UpdateUser(user);
    }

    [HttpDelete("DeleteUser")]
    public async Task<Response<string>> DeleteUser(int id)
    {
        return await _userService.DeleteUser(id);
    }

    [HttpGet("GetPurchasedProducts")]
    public async Task<Response<List<PurchasedProducts>>> GetPurchasedProducts()
    {
        return await _userService.GetPurchasedProducts();
    }

    [HttpGet("Gets")]
    public async Task<Response<PurchasedProducts>> Get(GetProductCreditDto credit)
    {
        return await _userService.Get(credit);
    }

    
}

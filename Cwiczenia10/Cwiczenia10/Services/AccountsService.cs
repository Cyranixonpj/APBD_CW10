using Cwiczenia10.Contexts;
using Cwiczenia10.Exceptions;
using Cwiczenia10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10.Services;


public interface IAccountsService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id);
}


public class AccountsService(DataBaseContext context) : IAccountsService
{
    public async Task<GetAccountResponseModel> GetAccountByIdAsync(int id)
    {
        var result = await context.Accounts
            .Where(e => e.AccountId == id)
            .Select(a => new GetAccountResponseModel
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Phone = a.Phone,
                Role = a.Role.Name,
                Cart = a.ShoppingCarts.Select(sc => new CartInfo
                {
                    ProductId = sc.ProductId,
                    ProductName = sc.Products.Name,
                    Amount = sc.Amount

                }).ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Account with {id} does not exist");
        }

        return result;
    }
}
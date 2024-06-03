using Cwiczenia10.Models;

namespace Cwiczenia10.ResponseModels;

public class GetAccountResponseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Role { get; set; }
    
    public List<CartInfo> Cart { get; set; }
    
    
}

public class CartInfo
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
}
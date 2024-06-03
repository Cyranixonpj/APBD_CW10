using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

public class ShoppingCarts
{
    
    [Column("amount")]
    public int Amount { get; set; }

    public Accounts Accounts { get; set; }
    public Products Products { get; set; }
    
    [Key]
    [ForeignKey("Accounts")]
    [Column("FK_account")]
    public int AccountId { get; set; }
    
    [Key]
    [ForeignKey("Products")]
    [Column("FK_product")]
    public int ProductId { get; set; }
    
}
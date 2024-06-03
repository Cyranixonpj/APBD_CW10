using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

public class Products
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("weight",TypeName = "decimal(5,2)")]
    public decimal Weight { get; set; }
    
    [Column("width",TypeName = "decimal(5,2)")]
    public decimal Width { get; set; }

    [Column("height",TypeName = "decimal(5,2)")]
    public decimal Height { get; set; }
    
    [Column("depth",TypeName = "decimal(5,2)")]
    public decimal Depth { get; set; }
    
    public IEnumerable<ShoppingCarts> ShoppingCarts { get; set; }
    
    public IEnumerable<ProductsCategories>ProductsCategories { get; set; }
}
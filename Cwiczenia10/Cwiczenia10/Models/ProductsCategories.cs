using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

public class ProductsCategories
{
    [Key]
    [ForeignKey("Categories")]
    [Column("FK_category")]
    public int CategoryId { get; set; }
    
    [Key]
    [ForeignKey("Products")]
    [Column("FK_product")]
    public int ProductId { get; set; }
    
    
    public Categories Categories { get; set; }
    public Products Products { get; set; }
}
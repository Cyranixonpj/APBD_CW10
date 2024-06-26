using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cwiczenia10.Models;

public class Categories
{
    [Key]
    [Column("PK_category")]
    public int CategoryId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public IEnumerable<ProductsCategories> ProductsCategories { get; set; }
}
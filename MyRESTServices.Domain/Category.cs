using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRESTServices.Domain.Models;

public partial class Category
{
    [Key]
    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string? CategoryName { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}

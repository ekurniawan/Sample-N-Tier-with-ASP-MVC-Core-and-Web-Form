using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRESTServices.Domain.Models;

public partial class Article
{
    [Key]
    [Column("ArticleID")]
    public int ArticleId { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    public string? Details { get; set; }

    public DateOnly PublishDate { get; set; }

    public bool IsApproved { get; set; }

    public string? Pic { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Articles")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("Username")]
    [InverseProperty("Articles")]
    public virtual User UsernameNavigation { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRESTServices.Domain.Models;

public partial class User
{
    [Key]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime LastLogin { get; set; }

    public bool IsLocked { get; set; }

    public byte MaxAttempt { get; set; }

    [StringLength(255)]
    public string FirstName { get; set; } = null!;

    [StringLength(255)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string? Telp { get; set; }

    [StringLength(255)]
    public string? SecurityQuestion { get; set; }

    [StringLength(255)]
    public string? SecurityAnswer { get; set; }

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [ForeignKey("Username")]
    [InverseProperty("Usernames")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

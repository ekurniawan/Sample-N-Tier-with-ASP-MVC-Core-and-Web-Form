using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRESTServices.Domain.Models;

public partial class Country
{
    [Key]
    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(50)]
    public string CountryName { get; set; } = null!;

    [InverseProperty("Country")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}

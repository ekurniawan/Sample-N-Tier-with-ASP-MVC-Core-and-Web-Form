using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRESTServices.Domain.Models;

public partial class City
{
    [Key]
    [Column("CityID")]
    public int CityId { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(50)]
    public string CityName { get; set; } = null!;

    [ForeignKey("CountryId")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}

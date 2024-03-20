using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyRESTServices.Models;

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

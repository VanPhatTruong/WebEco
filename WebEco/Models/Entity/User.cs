using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebEco.Models.Entity;

[Table("User")]
public partial class User
{
    [Key]
    [StringLength(300)]
    public string Id { get; set; } = null!;

    [StringLength(500)]
    public string? Email { get; set; }

    public int? Sdt { get; set; }

    [StringLength(500)]
    public string? Adress { get; set; }
}

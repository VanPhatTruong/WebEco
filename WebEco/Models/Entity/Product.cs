using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebEco.Models.Entity;

[Table("Product")]
public partial class Product
{
    [Key]
    public string Id { get; set; } = null!;

    [StringLength(150)]
    public string? TenSanPham { get; set; }

    [StringLength(150)]
    public string? Mota { get; set; }

    [Column(TypeName = "money")]
    public decimal? Gia { get; set; }

    [StringLength(1000)]
    public string? Filter { get; set; }
    public bool IsActive { get; set; } = true;
    public string? UrlImage { get; set; }
}

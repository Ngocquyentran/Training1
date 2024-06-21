using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp2.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? Brand { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }
}

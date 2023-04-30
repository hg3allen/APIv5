using System;
using System.Collections.Generic;

namespace APIv5.Models;

public partial class Card
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LicensePlate { get; set; }

    public string? ImagePath { get; set; }
}

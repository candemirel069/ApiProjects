using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Location.SampleApp.Models;

public partial class Ilce
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public int SehirId { get; set; }

    public virtual City Sehir { get; set; } = null!;
}

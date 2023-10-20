using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Location.SampleApp.Models;

public partial class City
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public List<Ilce> Ilce { get; } = new List<Ilce>();
}

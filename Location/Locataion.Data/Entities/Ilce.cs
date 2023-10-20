using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Locataion.Data.Entities;

public partial class Ilce
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public int SehirId { get; set; }

    [JsonIgnore]
    public virtual Sehir Sehir { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.SampleConsoleApp.Models;

public partial class Ilce
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public int SehirId { get; set; }

    public virtual Sehir Sehir { get; set; } = null!;
}

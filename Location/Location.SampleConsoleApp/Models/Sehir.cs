namespace Location.SampleConsoleApp.Models;

public partial class Sehir
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public List<Ilce> Ilce { get; } = new List<Ilce>();
}

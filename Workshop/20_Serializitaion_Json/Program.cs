using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

public class Sehir
{
    public int Id { get; set; } = Program.UID++;
    public string? Adi { get; set; }
    public string? Plaka { get; set; }

    //[JsonIgnore]
    public List<Ilce> Ilceler { get; set; }
}

public class Ilce
{
    public int Id { get; set; } = Program.UID++;
    public string Adi { get; set; }
}
public class SehirListesi : List<Sehir> { }

internal class Program
{
    public static SehirListesi GetData1() => new SehirListesi            {
                new Sehir
                {
                    Adi = "Istanbul",
                    Plaka = "34"
                },
                new Sehir
                {
                    Adi = "Ankara",
                    Plaka = "06"
                }
            };

    public static SehirListesi GetData2()
    {
        var list = new SehirListesi();
        list.Add(new Sehir
        {
            Adi = "Istanbul",
            Plaka = "34",
            Ilceler = new List<Ilce> {
                new Ilce { Adi = "Beşiktaş" },
                new Ilce { Adi = "Şişli" },
                new Ilce { Adi = "Taksim" }
                }
        });
        list.Add(new Sehir
        {
            Adi = "Ankara",
            Plaka = "06",
            Ilceler = new List<Ilce> {
                new Ilce { Adi = "Maltepe" },
                new Ilce { Adi = "Çankaya" },
                new Ilce { Adi = "Tandoğan" }
                }
        });
        return list;
    }

    public static int UID = 1;
    static void Main(string[] args)
    {
        var data = GetData2();

        var jsonString = JsonSerializer.Serialize(data,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All)
            });
        Console.WriteLine(jsonString);
    }
}
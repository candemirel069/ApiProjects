var baseAddress = "https://localhost:5555/api/";

function GetSehirDetay(sehirId) {
    $.ajax({
        url: baseAddress + "Sehirler/" + sehirId,
        method: "GET",
        success: function (data) {
            //debugger;
            $("#h-sehir-adi").text(data.adi);
            var tableString = "";
            $.each(data.ilce, function (index, value) {
                tableString += "<tr><td>" + value.id + "</td><td>" + value.adi + "</td></tr>";
            });
            $("#table1").append(tableString);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetSehirListesi() {
    $.ajax({
        url: baseAddress + "Sehirler",
        method: "GET",
        success: function (res) {
            var tableString = "";
            $.each(res, function (index, value) {
                tableString += "<tr><td>" + value.id + "</td><td>" + value.adi + "</td>";
                tableString += "<td><a href='/LocationsClient/Details?SehirId=" + value.id + "'>Şehre Git</a></td></tr>";
            });
            $("#table1").append(tableString);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
using Location.SampleApp.Code;
using Location.SampleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Location.SampleApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationApiClient _client;

        public LocationsController(LocationApiClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _client.GetAsync<City>("Sehirler"));
        }


        public async Task<IActionResult> Details(int id)
        {
            var a = await _client.GetAsync<City>("Sehirler", id);
            return View(a);
        }
    }


}

using Microsoft.AspNetCore.Mvc;
using SeminarskaNaloga.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using SeminarskaNaloga.Data.interfaces;
namespace SeminarskaNaloga.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtikelRepository _artikelRepository;

        public HomeController(IArtikelRepository artikelRepository)
        {
            _artikelRepository = artikelRepository;
        }

        public IActionResult Index()
        {   
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
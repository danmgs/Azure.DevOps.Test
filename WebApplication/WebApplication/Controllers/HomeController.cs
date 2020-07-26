using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Model;
using WebApplication.Service;

namespace WebApplication.Api.Controllers
{
    public class HomeController : Controller
    {
        readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            List<Product> model = _homeService.Add(new Product() { Id = 1, Name = "Computer", Qty = 20 });

            model.ForEach(p => p.Status = "Home");

            ViewBag.Model = model;
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

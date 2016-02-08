using Microsoft.AspNet.Mvc;
using TagHelperDemo.Mvc.Models;

namespace TagHelperDemo.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(IndexModel model) => View(model);
    }
}

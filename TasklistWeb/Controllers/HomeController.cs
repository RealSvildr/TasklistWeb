using Microsoft.AspNetCore.Mvc;

namespace TasklistWeb.Controllers {
    public class HomeController : BaseController {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Task() {
            return View();
        }
        public IActionResult Priority() {
            return View();
        }

        public RedirectToActionResult RedirectPriority() {
            return RedirectToAction("Priority");
        }
    }
}

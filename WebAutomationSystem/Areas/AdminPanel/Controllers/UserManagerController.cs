using Microsoft.AspNetCore.Mvc;

namespace WebAutomationSystem.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

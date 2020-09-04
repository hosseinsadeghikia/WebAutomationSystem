using Microsoft.AspNetCore.Mvc;

namespace WebAutomationSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        public string method1()
        {
            return "Hello from Index";
        }

        [Route("contact-us/{mobile:int}")]
        public string method2(int mobile)
        {
            return "Contact us at: " + mobile;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        public string method1()
        {
            return "Hello from Index";
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        public string method1()
        {
            //Dessa forma estou retornando no body da requisição o texto "Hello from Index" e o tipo do conteúdo é "text/plain"
            return new ContentResult { Content = "Hello from Index", ContentType = "text/plain" }.Content;

            //Posso ambém fazer da maneira mais curta. Conforme esse exemplo:
            //return Content("Hello from Index", "text/plain").Content;

            //Também posso retorna tags HTML, como por exemplo:
            //return Content("<h1>Hello from Index</h1>", "text/html").Content;
        }

        [Route("contact-us/{mobile:int}")]
        public string method2(int mobile)
        {
            return "Contact us at: " + mobile;
        }
    }
}

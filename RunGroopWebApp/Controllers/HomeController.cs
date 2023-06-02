using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Models;
using System.Diagnostics;

namespace RunGroopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PuntoDeVentaContext _context_ = new PuntoDeVentaContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            // Se obtienen los registros de la tabla Empleados y se convierten en una lista para que se puedan manejar más fácilmente
            var empleados = _context_.Empleados.ToList();

            //foreach (var empleado in empleados)
            //{
            //    Console.WriteLine(empleado.NombreEmpleado);
            //}

            // Una vista es un archivo Razor
            // Razor no es más que un archivo que combina HTML con C#
            return View(empleados);

            /*
            Si te preguntas cómo es que "View" sabe a cual plantilla renderizar,
            Solo tienes que revisar en la carpeta "Views" y aparecerán carpetas con el nombre de los controladores (Exceptuando 'Shared')
            además de que por ejemplo, fijese que el nombre de la carpeta "Home" que tiene el mismo nombre que el controlador, 
            (Solamente quita la palabra 'Controller' del final) y ejecutará la plantilla que se llame "index.cshtml"
             */
        }

        public IActionResult Privacy()
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
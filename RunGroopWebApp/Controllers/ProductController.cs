using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Models;
using RunGroopWebApp.Models.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class ProductController : Controller
    {
        /*
         * El controlador es accedido desde la vista del layout con una propiedad propia de ASP.net:
         * aps-controler = Hace referencia al controlador al cual va a apuntar
         * asp-action =    Se trata de la función que va a ser ejecutada dentro del controlador ya mencionado
         * 
         * Entonces dentro del Layout se hizo referencia a este controlador.
         * 
         * Para ver el layout es ir a la carpeta "Views", en la carpeta "Shared" verás un archivo llamado "_Layout.cshtml"
         * ese es el layout donde se hace la referencia a este controlador
         */

        // Contexto
        private readonly PuntoDeVentaContext? _context_;

        // Constructor
        public ProductController(PuntoDeVentaContext context)
        {
            _context_ = context;
        }

        public IActionResult Index()
        {
            // Se obtienen los productos y se transforman en una lista con objetos que representan cada registro de la tabla
            List<Producto> listaProductos = _context_.Productos.ToList();

            // Se renderiza la plantilla junto con la lista que obtuvimos
            return View(listaProductos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Sirve para proteger contra ataques de falsificación y asegurarse que la información enviada proviene del formulario
        public ActionResult Crear(ProductViewModel model)
        {
            /*
             * Se verifica si el modelo pasa las validaciones y todo ocurre correctamente
             */
            if (ModelState.IsValid)
            {
                // Se obtiene un objeto de producto del Entity Framework
                // Y se asignan los datos
                var producto = new Producto()
                {
                    NombreProducto = model.NombreProducto,
                    Precio = model.PrecioProducto,
                    Descripcion = model.DescripcionProducto
                };

                // Se guardan los cambios por medio de context
                _context_.Productos.Add(producto);
                _context_.SaveChanges();

                // Se redirige a la página de productos
                return RedirectToAction(nameof(Index));
            }

            // En caso de tener valores inválidos, entonces vuelve a la vista de Crear y rellena los campos con lo que ya teníamos
            return View(model);
        }

        // Método (Acción) de eliminar un registro de la tabla "Productos"
        [HttpGet]
        public ActionResult Eliminar (int id)
        {
            // Se busca el producto que se desea eliminar
            var product = _context_.Productos.Find(id);

            if (product != null)
            {
                // Una vez encontrado, se elimina
                _context_.Productos.Remove(product);

                // Se guardan los cambios
                _context_.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

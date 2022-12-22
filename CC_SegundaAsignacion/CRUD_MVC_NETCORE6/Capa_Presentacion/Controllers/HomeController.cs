using Capa_Datos;
using Capa_LogicaNegocio.Service;
using Capa_Presentacion.Models;
using Capa_Presentacion.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Capa_Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIngenieroService _ingenieroService;

        public HomeController(IIngenieroService ingenieroServ)
        {
            _ingenieroService = ingenieroServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Lista()
        {
            IQueryable<Ingeniero> queryIngSQL = await _ingenieroService.ObtenerTodos();

            List<VMIngeniero> lista = queryIngSQL
                                      .Select(i => new VMIngeniero()
                                      {
                                          Id = i.Id,
                                          Nombre = i.Nombre,
                                          Edad = i.Edad,
                                          FechaNac = i.FechaNac.Value.ToString("dd/MM/yyyy"),
                                          Altura = i.Altura
                                      }).ToList();

            return StatusCode(StatusCodes.Status200OK,lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody]VMIngeniero modelo)
        {
            Ingeniero NuevoModelo = new Ingeniero()
            {
                Nombre = modelo.Nombre,
                Edad = modelo.Edad,
                FechaNac = DateTime.ParseExact(modelo.FechaNac, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-SV")),
                Altura = modelo.Altura
            };

            bool respuesta = await _ingenieroService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMIngeniero modelo)
        {
            Ingeniero NuevoModelo = new Ingeniero()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                Edad = modelo.Edad,
                FechaNac = DateTime.ParseExact(modelo.FechaNac, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-SV")),
                Altura = modelo.Altura
            };

            bool respuesta = await _ingenieroService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _ingenieroService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

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
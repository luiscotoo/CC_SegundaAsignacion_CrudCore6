using Microsoft.AspNetCore.Mvc;
using modelEntity;
using modelNeg;

namespace WebMVC6.Controllers
{
    public class IngenieroController : Controller
    {
        private IngenieroNeg objIngenieroNeg;
        public IngenieroController()
        {
            objIngenieroNeg = new IngenieroNeg();
        }
        // GET: Ingeniero
        public ActionResult Inicio()
        {
            List<Ingeniero> lista = objIngenieroNeg.findAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicio();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ingeniero objIngeniero)
        {
            mensajeInicio();
            objIngenieroNeg.create(objIngeniero);
            mensajeErrorRegistro(objIngeniero);
            return View();
        }
        public void mensajeInicio()
        {
            ViewBag.mensajeInicio = "Formulario de Registro de Ingenieros";
        }
        public void mensajeInicioUpdate()
        {
            ViewBag.mensajeInicio = "Formulario para actualizar ingeniero";
        }
        public void mensajeInicioDelete()
        {
            ViewBag.mensajeInicio = "¿Eliminar este registro de ingeniero?";
        }

        public void mensajeErrorRegistro(Ingeniero objIngeniero)
        {
            switch (objIngeniero.Estado)
            {
                case 10:
                    ViewBag.mensajeError = "";
                    break;

                case 1:
                    ViewBag.mensajeError = "";
                    break;

                case 100:
                    ViewBag.mensajeError = "solo se permiten numeros";
                    break;

                case 20:
                    ViewBag.mensajeError = "Campo Nombre Esta Vacio";
                    break;

                case 2:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena en el campo nombre,solo se permiten 50 caracteres";
                    break;

                case 30:
                    ViewBag.mensajeError = "Campo Edad Esta Vacio";
                    break;

                case 3:
                    ViewBag.mensajeError = "Ingrese una edad valida";
                    break;

                case 40:
                    ViewBag.mensajeError = "Campo fecha nacimiento Esta Vacio";
                    break;

                case 4:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena en el campo fecha nacimiento";
                    break;

                case 5:
                    ViewBag.mensajeError = "Ingeniero [" + objIngeniero.Id + "]ya esta registrado";
                    break;
                case 25:
                    ViewBag.mensajeError = "Error al eliminar el registro";
                    break;
                case 69:
                    ViewBag.mensajeError = "Error al actualizar registro";
                    break;

                case 99:
                    ViewBag.mensajeExito = "El Ingeniero fue registrado con éxito";
                    break;

                case 45:
                    ViewBag.mensajeExito = "Se ha eliminado el registro con éxito";
                    break;
                case 68:
                    ViewBag.mensajeExito = "Se ha actualizado el registro con éxito";
                    break;





            }
        }

        public ActionResult Find(string codigo)
        {
            Ingeniero objIngeniero = new Ingeniero(Convert.ToInt32(codigo));
            objIngenieroNeg.find(objIngeniero);
            return View(objIngeniero);
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            mensajeInicioUpdate();
            Ingeniero objIngeniero = new Ingeniero(Convert.ToInt32(id));
            objIngenieroNeg.find(objIngeniero);
            return View(objIngeniero);
        }
        [HttpPost]
        public ActionResult Update(Ingeniero objIngeniero)
        {
            mensajeInicioUpdate();  
            objIngenieroNeg.update(objIngeniero);
            mensajeErrorRegistro(objIngeniero);
            return View();
        }
        
        public ActionResult Delete()
        {
            mensajeInicioDelete();
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Ingeniero objIngeniero)
        {
            mensajeInicioDelete();
            objIngenieroNeg.delete(objIngeniero);
            mensajeErrorRegistro(objIngeniero);
            return View();
        }
    }
}

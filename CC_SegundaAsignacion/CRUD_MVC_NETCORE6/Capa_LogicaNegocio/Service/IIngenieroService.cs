using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_LogicaNegocio.Service
{
    public interface IIngenieroService
    {
        Task<bool> Insertar(Ingeniero modelo);

        Task<bool> Actualizar(Ingeniero modelo);

        Task<bool> Eliminar(int id);

        Task<Ingeniero> Obtener(int id);

        Task<IQueryable<Ingeniero>> ObtenerTodos();
    }
}

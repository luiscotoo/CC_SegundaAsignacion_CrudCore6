using Capa_Datos;
using Capa_Datos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_LogicaNegocio.Service
{
    public class IngenieroService : IIngenieroService
    {
        private readonly IGenericRepository<Ingeniero> _ingRepo;
        public IngenieroService(IGenericRepository<Ingeniero> ingRepo) 
        { 
            _ingRepo= ingRepo;
        }
        public async Task<bool> Actualizar(Ingeniero modelo)
        {
            return await _ingRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _ingRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Ingeniero modelo)
        {
            return await _ingRepo.Insertar(modelo);
        }

        public async Task<Ingeniero> Obtener(int id)
        {
            return await(_ingRepo.Obtener(id));
        }

        public async Task<IQueryable<Ingeniero>> ObtenerTodos()
        {
            return await _ingRepo.ObtenerTodos();
        }
    }
}

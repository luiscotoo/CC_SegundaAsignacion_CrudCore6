using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos.DataContext;

namespace Capa_Datos.Repositories
{
    public class IngenieroRepository : IGenericRepository<Ingeniero>
    {

        private readonly CrudMvcContext _dbcontext;
        public IngenieroRepository(CrudMvcContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Ingeniero modelo)
        {
            _dbcontext.Ingenieros.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            Ingeniero modelo = _dbcontext.Ingenieros.First(i => i.Id == id);
            _dbcontext.Ingenieros.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Ingeniero modelo)
        {
            _dbcontext.Ingenieros.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Ingeniero> Obtener(int id)
        {
            return await _dbcontext.Ingenieros.FindAsync(id);
        }

        public async Task<IQueryable<Ingeniero>> ObtenerTodos()
        {
            IQueryable<Ingeniero> queryIngenieroSQL = _dbcontext.Ingenieros;
            return queryIngenieroSQL;
        }
    }
}

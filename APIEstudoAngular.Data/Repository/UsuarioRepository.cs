using APIEstudoAngular.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using APIEstudoAngular.Business.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIEstudoAngular.Data.Models;

namespace APIEstudoAngular.Data.Repository
{
    public class UsuarioRepository : Repository<Usuarios>, IUsuarioRepository
    {
        public UsuarioRepository(DevIoDbContext context) : base(context) { }

        public async Task<Usuarios> ObterTelefoneUsuario(Guid id)
        {
            return await _db.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Usuarios>> ObterTodosUsuarios()
        {          
            return await _db.Usuarios.AsNoTracking().Include(x => x.TipoUsuario).ToListAsync();
        }
    }
}

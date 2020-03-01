using APIEstudoAngular.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIEstudoAngular.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuarios>
    {
        Task<Usuarios> ObterTelefoneUsuario(Guid id);
        Task<IEnumerable<Usuarios>> ObterTodosUsuarios();
    }
}

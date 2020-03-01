using APIEstudoAngular.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudoAngular.Business.Interfaces
{
    public interface IUsuarioService
    {
        Task Adicionar(Usuarios usuarios);
        Task Atualizar(Usuarios usuarios);
        Task Remover(Guid id);
        Task<IEnumerable<Usuarios>> ObterTodosUsuario();
        Task<Usuarios> ObterPorId(Guid id);
        Task<string> ObterTelefoneUsuario(Guid id);
        Task<bool> UsuariosExists(Guid id);
    }
}

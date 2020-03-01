using APIEstudoAngular.Business.Interfaces;
using APIEstudoAngular.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudoAngular.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task Adicionar(Usuarios usuarios)
        {
            await _usuarioRepository.Adicionar(usuarios);
        }

        public async Task Atualizar(Usuarios usuarios)
        {
            await _usuarioRepository.Atualizar(usuarios);
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepository.Remover(id);
        }

        public async Task<IEnumerable<Usuarios>> ObterTodosUsuario()
        {         
            return await _usuarioRepository.ObterTodosUsuarios();
        }

        public async Task<Usuarios> ObterPorId(Guid id)
        {
            return await _usuarioRepository.ObterPorId(id);
        }

        public async Task<string> ObterTelefoneUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.ObterTelefoneUsuario(id);
            return usuario.Telefone;
        }

        public async Task<bool> UsuariosExists(Guid id)
        {
            return await _usuarioRepository.UsuariosExists(id);
        }
    }
}

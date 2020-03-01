using APIEstudoAngular.API.DTOs;
using APIEstudoAngular.API.Extensions;
using APIEstudoAngular.Business.Interfaces;
using APIEstudoAngular.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIEstudoAngular.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]  
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuarios()
        {
            return _mapper.Map<List<UsuarioDTO>>(await _usuarioService.ObterTodosUsuario());
        }

        [HttpGet("telefone/{id:Guid}")]
        public async Task<ActionResult<string>> GetTelefoneUsuario(Guid id)
        {
            return await _usuarioService.ObterTelefoneUsuario(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarios(Guid id)
        {
            var usuarios = _mapper.Map<UsuarioDTO>(await _usuarioService.ObterPorId(id));

            if (usuarios == null) return NotFound();

            return usuarios;
        }

        [ClaimsAuthorize("Usuario", "Atualizar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, UsuarioDTO usuarios)
        {
            if (id != usuarios.Id) return BadRequest();

            try
            {
                await _usuarioService.Atualizar(_mapper.Map<Usuarios>(usuarios));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _usuarioService.UsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    BadRequest();
                }
            }

            return NoContent();
        }

        [ClaimsAuthorize("Usuario", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Adicionar(UsuarioDTO usuarios)
        {
            try
            {
                await _usuarioService.Adicionar(_mapper.Map<Usuarios>(usuarios));
            }
            catch (DbUpdateException)
            {
                if (await _usuarioService.UsuariosExists(usuarios.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarios", new { id = usuarios.Id }, usuarios);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(Guid id)
        {
            try
            {
                await _usuarioService.Remover(id);
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

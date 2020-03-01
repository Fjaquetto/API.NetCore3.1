using System;
using System.ComponentModel.DataAnnotations;

namespace APIEstudoAngular.API.DTOs
{
    public class UsuarioDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int IdTipoUsuario { get; set; }
        public string DescricaoTipoUsuario { get; set; }
        public virtual TipoUsuarioDTO TipoUsuario { get; set; }
    }
}

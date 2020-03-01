using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEstudoAngular.API.DTOs
{
    public class TipoUsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        public string DescricaoTipoUsuario { get; set; }
        public virtual ICollection<UsuarioDTO> Usuarios { get; set; }
    }
}

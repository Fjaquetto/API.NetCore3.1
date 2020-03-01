﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEstudoAngular.Business.Models
{
    public partial class TipoUsuarios : Entity
    {
        public TipoUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        public int Id { get; set; } 
        [Required]
        [StringLength(100)]
        public string DescricaoTipoUsuario { get; set; }

        //[InverseProperty("IdTipoUsuarioNavigation")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
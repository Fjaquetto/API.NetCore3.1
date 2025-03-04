﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEstudoAngular.Business.Models
{
    public partial class Usuarios : Entity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required]
        [StringLength(500)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(10)]
        public string Telefone { get; set; }
        public int IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuarios.Usuarios))]
        public virtual TipoUsuarios TipoUsuario { get; set; }
    }
}
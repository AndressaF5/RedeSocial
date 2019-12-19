using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dominio
{
    public class Amizade
    {
        public int UsuarioIdA { get; set; }
        public int UsuarioIdB { get; set; }
        [DisplayName("Usuario")]
        public Usuario UsuarioA { get; set; }
        [DisplayName("Seguindo")]
        public Usuario UsuarioB { get; set; }
    }
}

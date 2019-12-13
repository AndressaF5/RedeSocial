using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Amizade
    {
        public int UsuarioIdA { get; set; }
        public int UsuarioIdB { get; set; }
        public Usuario UsuarioA { get; set; }
        public Usuario UsuarioB { get; set; }
    }
}

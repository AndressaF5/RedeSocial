using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class UsuarioEvento
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}

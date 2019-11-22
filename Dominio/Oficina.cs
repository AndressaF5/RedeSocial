using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Oficina
    {
        public int Id { get; set; }
        public int QtdPrticipantes { get; set; }
        public List<Usuario> ListaParticipantes { get; set; }

        public static Boolean VerificarDisponibilidade()
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Arrecadacao
    {
        public int Id { get; set; }
        public int QtdParticipantes { get; set; }
        public float QtdAlimento { get; set; }
        public float MetaArrecadacao { get; set; }
        public int IdadePublicoAlvo { get; set; }

        public static void ImprimirTipo()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Doacao
    {
        public int Id { get; set; }
        public float ValorDoacao { get; set; }
        public float MetaArrecadacao { get; set; }
        public float ValorArrecadacao { get; set; }

        public static void CalcularValorArrecadacao()
        {

        }
    }
}

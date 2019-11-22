using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Genero { get; set; }

        public static void ImprimirTipo()
        {

        }
    }
}

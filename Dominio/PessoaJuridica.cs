using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PessoaJuridica
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }

        public static void ImprimirTipo()
        {

        }
    }
}

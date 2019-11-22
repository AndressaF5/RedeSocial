using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Usuario
    {
        public int Id { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public Contato Contato { get; set; }
    }
}

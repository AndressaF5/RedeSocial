using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PessoaJuridica : Usuario
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public Endereco Endereco { get; set; }

        
	    public void divulgar() {
		    base.divulgar();
		    Console.WriteLine(":: Dados da empresa ::\n"
				    + "Nome da empresa: %s \n"
				    + "Razao Social: %s \n"
				    + "CNPJ: %s \n",
				    NomeEmpresa,
				    RazaoSocial,
				    CNPJ
				    );
	    }
	
    }
}

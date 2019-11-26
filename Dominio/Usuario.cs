using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public Contato Contato { get; set; }
        public ICollection<UsuarioEvento> Evento { get; set; }
    
        
	    public void divulgar() {
		 /*   Console.WriteLine(":: Dados pessoais ::\n "
				    + "Usuário: %s \n "
				    + "Senha: %s \n",
				   //Usuario,
				   //Senha
				    );*/
		    Contato.divulgar();
	    }

    }
}

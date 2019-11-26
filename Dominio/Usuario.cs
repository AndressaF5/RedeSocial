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
<<<<<<< HEAD
        public ICollection<Evento> Evento { get; set; }
        public ICollection<UsuarioEvento> UsuarioEvento { get; set; }

        public void divulgar() {
		    Console.WriteLine(":: Dados pessoais ::\n "
=======
        public ICollection<UsuarioEvento> Evento { get; set; }
    
        
	    public void divulgar() {
		 /*   Console.WriteLine(":: Dados pessoais ::\n "
>>>>>>> 7199ed76ed076aff7a74aa678933aff4a330be1d
				    + "Usuário: %s \n "
				    + "Senha: %s \n",
				   //Usuario,
				   //Senha
				    );*/
		    Contato.divulgar();
	    }

    }
}

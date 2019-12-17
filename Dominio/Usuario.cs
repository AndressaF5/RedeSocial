using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Genero { get; set; }
        public Contato Contato { get; set; }
        public ICollection<Evento> Evento { get; set; }
        public ICollection<UsuarioEvento> UsuarioEvento { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public ICollection<Amizade> AmizadesSolicitadas { get; set; }
        public ICollection<Amizade> AmizadesRecebidas { get; set; }


	  //  public void divulgar() {
		 ///*   Console.WriteLine(":: Dados pessoais ::\n "
			//	    + "Usuário: %s \n "
			//	    + "Senha: %s \n",
			//	   //Usuario,
			//	   //Senha
			//	    );*/
		 //   Contato.divulgar();
	  //  }

    }
}

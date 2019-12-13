using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Genero { get; set; }
        public Contato Contato { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public ICollection<Amizade> AmizadesSolicitadas { get; set; }
        public ICollection<Amizade> AmizadesRecebidas { get; set; }

        //   public void divulgar() {
        //     base.divulgar();
        //  Console.WriteLine(":: Dados Pessoais ::\n"
        //    + "Nome: %s \n"
        //    + "Nome Social: %s \n"
        //    + "Data de Nascimento (DD/MM/AA): %s \n"
        //    + "CPF: %s \n"
        //    + "Genero: %s\n",
        //     Nome,    
        //     NomeSocial,   
        //     DataNascimento, 
        //     CPF,            
        //     Genero               
        //    );
        //}

    }
}

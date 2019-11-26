using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Evento
    {
        public int Id { get; set; }
        public string NomeAtividade { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
<<<<<<< HEAD
        public ICollection<UsuarioEvento> UsuarioEvento { get; set; }
	    
	    public void divulgar() {
		    Console.WriteLine("Nome da Atividade: %s \n" 
				    + "Data: %s \n" 
		    		+ "Hora:%s \n"
				    + "Categoria: %s \n" 
				    + "Descrição: %s \n", 
				    this.NomeAtividade, 
				    this.Data, 
			        this.Hora, 
				    this.Categoria,
				    this.Descricao
				    );
		}
        
=======

        public void divulgar()
        {
            Console.WriteLine("Nome da Atividade: %s \n"
                    + "Data: %s \n"
                    + "Hora:%s \n"
                    + "Categoria: %s \n"
                    + "Descrição: %s \n",
                    NomeAtividade,
                    Data,
                    Hora,
                    Categoria,
                    Descricao
                    );

        }
>>>>>>> 7199ed76ed076aff7a74aa678933aff4a330be1d
    }
}

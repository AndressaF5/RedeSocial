﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Evento
    {
        public int Id { get; set; }
        public string NomeAtividade { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public Contato Contato { get; set; }
        public Oficina Oficina { get; set; }
        public Arrecadacao Arrecadacao { get; set; }
        public Doacao Doacao { get; set; }
        public ICollection<UsuarioEvento> UsuarioEvento { get; set; }
	    
	 //   public void divulgar() {
		//    Console.WriteLine("Nome da Atividade: %s \n" 
		//		    + "Data: %s \n" 
		//    		+ "Hora:%s \n"
		//		    + "Categoria: %s \n" 
		//		    + "Descrição: %s \n", 
		//		    this.NomeAtividade, 
		//		    this.Data, 
		//	        this.Hora, 
		//		    this.Categoria,
		//		    this.Descricao
		//		    );
		//}

  //      public void Divulgar()
  //      {
  //          Console.WriteLine("Nome da Atividade: %s \n"
  //                  + "Data: %s \n"
  //                  + "Hora:%s \n"
  //                  + "Categoria: %s \n"
  //                  + "Descrição: %s \n",
  //                  NomeAtividade,
  //                  Data,
  //                  Hora,
  //                  Categoria,
  //                  Descricao
  //                  );

  //      }
    }
}

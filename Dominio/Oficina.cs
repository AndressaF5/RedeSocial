﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Oficina : Evento
    {
        public int Id { get; set; }
        public int QtdPrticipantes { get; set; }
        public List<Usuario> ListaParticipantes { get; set; }

        public void verificarDisponibilidadeVaga() {
		    if (this.ListaParticipantes.length >= this.QtdParticipantes) {
			    Console.WriteLine("Não temos mais vagas. Fim da inscrições");
			
		    } else {
			    Console.WriteLine("Seja bem vindo(a)! Acompanhe sua inscrição!");
		    }
	    }

	    public void divulgar() {
            base(divulgar());
		    Console.WriteLine(":: Oficina ::\n "
				    + "Quantidade de participantes: %d",
				    this.QtdParticipantes
				    );
	    }
        
    }
}

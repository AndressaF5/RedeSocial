using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Arrecadacao : Evento
    {
        public int Id { get; set; }
        public int QtdParticipantes { get; set; }
        public float QtdAlimento { get; set; }
        public float MetaArrecadacao { get; set; }
        public int PublicoAlvo { get; set; }

	    public void divulgar() {
		    base(divulgar());
		    Console.WriteLine(":: Doações e Serviços ::\n "
		    +"Quantidade de doadores:%d \n" 
		    + "Quantidades de alimentos arrecadados até o momento: %.2f kg \n"
		    + "Meta de arrecadação: %.2f\n"
		    + "Publico alvo: %s\n"
		    + "Quantidade de pessoas a receberem brinquedos/roupas: %.2f \n",
		    this.QtdParticipantes,
		    this.QtdAlimentos,
		    this.MetaArrecadacao,
		    this.PublicoAlvo,
		    this.QtdAlimentos
		
		    );
	    }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Doacao : Evento
    {
        public int Id { get; set; }
        public float ValorDoacao { get; set; }
        public float MetaArrecadacao { get; set; }
        public float ValorArrecadado { get; set; }

        private float calcularValorArrecadado(float ValorArrecadado, float ValorDoacao) {
	        ValorArrecadado  = ValorArrecadado + ValorDoacao;
	        return ValorArrecadado;
	    }
	    public void verificarMeta() {
		    if (calcularValorArrecadado() >= this.MetaArrecadacao ) {
			    Console.WriteLine("Atingimos a meta! Nosso muito obrigado (a)!");
			
		    } else {
			    Console.WriteLine("Obrigada pela doação!");
		    }
	    }

	    public void divulgar() {
            base(divulgar());
		    Console.WriteLine(":: Doação ::\n "
				    + "Valor doação: %.2f"
				    + "Meta de arrecadação: %.2f"
				    + "Valor Arrecadado: %.2f",
				    ValorDoacao,
				    MetaArrecadacao,
				    ValorArrecadado
				    );
	    }


    }
}

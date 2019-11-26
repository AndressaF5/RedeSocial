using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Contato
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

    public void divulgar() {
	    Console.WriteLine(":: Contato :: \n "
			    + "Telefone:%s \n"
			    + "Celular: %s \n",
			    Telefone, 
			    Celular
			    );
    }

    }
}

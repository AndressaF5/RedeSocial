﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }

  //     public void divulgar() {
		//Console.WriteLine(":: Endereço ::\n CEP: %s\n"
		//		+ " %s, %s - %s, %s - %s \n",
		//		CEP,
		//		Rua,
		//		Complemento,
		//		Bairro,
		//		Cidade,
		//		UF
		//		);
	 //  }

    }
}

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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Oficina : Evento
    {
        public int Id { get; set; }
        public string NomeOficina { get; set; }
        public int QtdParticipantes { get; set; }
        public List<Usuario> ListaParticipantes { get; set; }

        public void verificarDisponibilidadeVaga(List<Usuario> ListaParticipantes, int QtdParticipantes)
        {
            if (ListaParticipantes.Count >= QtdParticipantes)
            {
                Console.WriteLine("Não temos mais vagas. Fim da inscrições");

            }
            else
            {
                Console.WriteLine("Seja bem vindo(a)! Acompanhe sua inscrição!");
            }
        }

        //public void divulgar() {
        //       base.divulgar();
        // Console.WriteLine(":: Oficina ::\n "
        //   + "Quantidade de participantes: %d",
        //               QtdParticipantes
        //               );
        //}

    }
}

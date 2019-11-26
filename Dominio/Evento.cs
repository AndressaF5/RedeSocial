using System;
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
        public Arrecadacao Arrecadacao { get; set; }
        public ICollection<UsuarioEvento> UsuarioEvento { get; set; }

        public static void ImprimirTipo()
        {

        }

        public static void Divulgar()
        {

        }
    }
}

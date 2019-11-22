using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Banco
{
    class RedeSocialDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=servidoredesocial.database.windows.net;Database=RedeSocialDB;Trusted_Connection=True;");
        }

        DbSet<Arrecadacao> Arrecadacoes { get; set; }
        DbSet<Contato> Contatos { get; set; }
        DbSet<Doacao> Doacoes { get; set; }

    }
}

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
            optionsBuilder.UseSqlServer("Server=tcp:servidoredesocial.database.windows.net,1433;Initial Catalog=RedeSocialDB;Persist Security Info=False;User ID=adminredesocial;Password=R&des0(1a1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        DbSet<Arrecadacao> Arrecadacoes { get; set; }
        DbSet<Contato> Contatos { get; set; }
        DbSet<Doacao> Doacoes { get; set; }

    }
}

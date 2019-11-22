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
            optionsBuilder.UseSqlServer("Server=servidoredesocial;database=RedeSocialDB;Trusted_Connection=true");
        }

        DbSet<Arrecadacao> Arrecadacoes { get; set; }

    }
}

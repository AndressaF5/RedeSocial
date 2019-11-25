using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Banco
{
    class RedeSocialDbContext : DbContext
    {
        DbSet<Arrecadacao> Arrecadacoes { get; set; }
        DbSet<Contato> Contatos { get; set; }
        DbSet<Doacao> Doacoes { get; set; }
        DbSet<Endereco> Enderecos { get; set; }
        DbSet<Evento> Eventos { get; set; }
        DbSet<Oficina> Oficinas { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<UsuarioEvento> UsuariosEventos { get; set; }

        public RedeSocialDbContext(DbContextOptions<RedeSocialDbContext> options) : base (options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:servidoredesocial.database.windows.net,1433;Initial Catalog=RedeSocialDB;Persist Security Info=False;User ID=adminredesocial;Password=R&des0(1a1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsuarioEvento>()
                .HasKey(ue => new { ue.UsuarioId, ue.EventoId });

            builder.Entity<UsuarioEvento>()
                .HasOne(ue => ue.Usuario)
                .WithMany(u => u.UsuarioEvento)
                .HasForeignKey(ue => ue.UsuarioId);

            builder.Entity<UsuarioEvento>()
                .HasOne(ue => ue.Evento)
                .WithMany(e => e.UsuarioEvento)
                .HasForeignKey(ue => ue.EventoId);
        }

    }
}

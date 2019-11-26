using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Banco
{
    public class RedeSocialDbContext : DbContext
    {        
        public DbSet<Arrecadacao> Arrecadacoes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioEvento> UsuariosEventos { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

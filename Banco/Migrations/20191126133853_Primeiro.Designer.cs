﻿// <auto-generated />
using System;
using Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banco.Migrations
{
    [DbContext(typeof(RedeSocialDbContext))]
    [Migration("20191126133853_Primeiro")]
    partial class Primeiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Arrecadacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdadePublicoAlvo");

                    b.Property<float>("MetaArrecadacao");

                    b.Property<float>("QtdAlimento");

                    b.Property<int>("QtdParticipantes");

                    b.HasKey("Id");

                    b.ToTable("Arrecadacoes");
                });

            modelBuilder.Entity("Dominio.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Dominio.Doacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("MetaArrecadacao");

                    b.Property<float>("ValorArrecadacao");

                    b.Property<float>("ValorDoacao");

                    b.HasKey("Id");

                    b.ToTable("Doacoes");
                });

            modelBuilder.Entity("Dominio.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Rua");

                    b.Property<string>("UF");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Dominio.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("EnderecoId");

                    b.Property<DateTime>("Hora");

                    b.Property<string>("NomeAtividade");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Eventos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Evento");
                });

            modelBuilder.Entity("Dominio.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Genero");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeSocial");

                    b.Property<string>("Sobrenome");

                    b.HasKey("Id");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("Dominio.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ");

                    b.Property<string>("NomeEmpresa");

                    b.Property<string>("RazaoSocial");

                    b.HasKey("Id");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContatoId");

                    b.Property<int?>("OficinaId");

                    b.Property<int?>("PessoaFisicaId");

                    b.Property<int?>("PessoaJuridicaId");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.HasIndex("OficinaId");

                    b.HasIndex("PessoaFisicaId");

                    b.HasIndex("PessoaJuridicaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Dominio.UsuarioEvento", b =>
                {
                    b.Property<int>("UsuarioId");

                    b.Property<int>("EventoId");

                    b.HasKey("UsuarioId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("UsuariosEventos");
                });

            modelBuilder.Entity("Dominio.Oficina", b =>
                {
                    b.HasBaseType("Dominio.Evento");

                    b.Property<int>("QtdPrticipantes");

                    b.ToTable("Oficina");

                    b.HasDiscriminator().HasValue("Oficina");
                });

            modelBuilder.Entity("Dominio.Evento", b =>
                {
                    b.HasOne("Dominio.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.HasOne("Dominio.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");

                    b.HasOne("Dominio.Oficina")
                        .WithMany("ListaParticipantes")
                        .HasForeignKey("OficinaId");

                    b.HasOne("Dominio.PessoaFisica", "PessoaFisica")
                        .WithMany()
                        .HasForeignKey("PessoaFisicaId");

                    b.HasOne("Dominio.PessoaJuridica", "PessoaJuridica")
                        .WithMany()
                        .HasForeignKey("PessoaJuridicaId");
                });

            modelBuilder.Entity("Dominio.UsuarioEvento", b =>
                {
                    b.HasOne("Dominio.Evento", "Evento")
                        .WithMany("UsuarioEvento")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dominio.Usuario", "Usuario")
                        .WithMany("UsuarioEvento")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

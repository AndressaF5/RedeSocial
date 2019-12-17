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
    [Migration("20191213232239_Quinto")]
    partial class Quinto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Amizade", b =>
                {
                    b.Property<int>("UsuarioIdA");

                    b.Property<int>("UsuarioIdB");

                    b.HasKey("UsuarioIdA", "UsuarioIdB");

                    b.HasIndex("UsuarioIdB");

                    b.ToTable("Amizade");
                });

            modelBuilder.Entity("Dominio.Arrecadacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("MetaArrecadacao");

                    b.Property<int>("PublicoAlvo");

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

                    b.Property<float>("ValorArrecadado");

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

                    b.Property<int?>("ArrecadacaoId");

                    b.Property<string>("Categoria");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<int?>("DoacaoId");

                    b.Property<int?>("EnderecoId");

                    b.Property<DateTime>("Hora");

                    b.Property<string>("NomeAtividade");

                    b.Property<int?>("OficinaId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ArrecadacaoId");

                    b.HasIndex("DoacaoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("OficinaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Dominio.Oficina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeOficina");

                    b.Property<int>("QtdParticipantes");

                    b.HasKey("Id");

                    b.ToTable("Oficinas");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<int?>("ContatoId");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Genero");

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeSocial");

                    b.Property<int?>("OficinaId");

                    b.Property<string>("Sobrenome");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.HasIndex("IdentityUserId");

                    b.HasIndex("OficinaId");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dominio.Amizade", b =>
                {
                    b.HasOne("Dominio.Usuario", "UsuarioA")
                        .WithMany("AmizadesSolicitadas")
                        .HasForeignKey("UsuarioIdA")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dominio.Usuario", "UsuarioB")
                        .WithMany("AmizadesRecebidas")
                        .HasForeignKey("UsuarioIdB")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dominio.Evento", b =>
                {
                    b.HasOne("Dominio.Arrecadacao", "Arrecadacao")
                        .WithMany()
                        .HasForeignKey("ArrecadacaoId");

                    b.HasOne("Dominio.Doacao", "Doacao")
                        .WithMany()
                        .HasForeignKey("DoacaoId");

                    b.HasOne("Dominio.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("Dominio.Oficina", "Oficina")
                        .WithMany()
                        .HasForeignKey("OficinaId");

                    b.HasOne("Dominio.Usuario")
                        .WithMany("Evento")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.HasOne("Dominio.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.HasOne("Dominio.Oficina")
                        .WithMany("ListaParticipantes")
                        .HasForeignKey("OficinaId");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

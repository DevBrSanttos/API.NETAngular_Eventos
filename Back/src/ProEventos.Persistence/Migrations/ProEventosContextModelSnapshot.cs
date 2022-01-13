﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(ProEventosContext))]
    partial class ProEventosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("dataEvento");

                    b.Property<string>("email");

                    b.Property<string>("imagemURL");

                    b.Property<string>("local");

                    b.Property<int>("qtdPessoas");

                    b.Property<string>("telefone");

                    b.Property<string>("tema");

                    b.HasKey("id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("dataFim");

                    b.Property<DateTime?>("dataInicio");

                    b.Property<int>("eventoId");

                    b.Property<string>("nome");

                    b.Property<decimal>("preco");

                    b.Property<int>("quantidade");

                    b.HasKey("id");

                    b.HasIndex("eventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("imagemURL");

                    b.Property<string>("miniCurriculo");

                    b.Property<string>("nome");

                    b.Property<string>("telefone");

                    b.HasKey("id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("eventoId");

                    b.Property<int>("palestranteId");

                    b.HasKey("eventoId", "palestranteId");

                    b.HasIndex("palestranteId");

                    b.ToTable("PalestrantesEventos");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("URL");

                    b.Property<int?>("eventoId");

                    b.Property<string>("nome");

                    b.Property<int?>("palestranteId");

                    b.HasKey("id");

                    b.HasIndex("eventoId");

                    b.HasIndex("palestranteId");

                    b.ToTable("RedesSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "evento")
                        .WithMany("lotes")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "evento")
                        .WithMany("palestrantesEventos")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProEventos.Domain.Palestrante", "palestrante")
                        .WithMany("palestrantesEventos")
                        .HasForeignKey("palestranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "evento")
                        .WithMany("redesSociais")
                        .HasForeignKey("eventoId");

                    b.HasOne("ProEventos.Domain.Palestrante", "palestrante")
                        .WithMany("redesSoiais")
                        .HasForeignKey("palestranteId");
                });
#pragma warning restore 612, 618
        }
    }
}
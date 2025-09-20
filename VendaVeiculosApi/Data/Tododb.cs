using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosApi.Data;
using VendaVeiculosApi.Models;

namespace VendaVeiculosApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Aluguel>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Aluguel>()
                .Property(a => a.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<Veiculo>()
                .HasKey(v => v.Id);
            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<Pagamento>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Pagamento>()
                .Property(p => p.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<Fabricante>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Fabricante>()
                .Property(f => f.Id)
                .HasColumnName("Id");

            // Relacionamentos
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Fabricante)
                .WithMany(f => f.Veiculos)
                .HasForeignKey(v => v.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Alugueis)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Veiculo)
                .WithMany(v => v.Alugueis)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Aluguel)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Restrições e índices
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CPF)
                .IsUnique();

            modelBuilder.Entity<Veiculo>()
                .HasIndex(v => v.Placa)
                .IsUnique();

            // Tipos decimais
            modelBuilder.Entity<Aluguel>()
                .Property(a => a.ValorDiaria)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Aluguel>()
                .Property(a => a.ValorTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pagamento>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}
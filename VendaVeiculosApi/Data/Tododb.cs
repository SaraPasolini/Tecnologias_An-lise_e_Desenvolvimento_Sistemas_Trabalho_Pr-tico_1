using System;
using Microsoft.EntityFrameworkCore;
using VendaVeiculosApi.Models;

namespace VendaVeiculosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluguel> Aluguei { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
    }
}
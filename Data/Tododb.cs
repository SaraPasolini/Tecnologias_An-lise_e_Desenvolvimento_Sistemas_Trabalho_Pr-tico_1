using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenderVeiculos.API
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options)
        {
        }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
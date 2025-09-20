using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosApi.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();

        [Required]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; } = new Veiculo();

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        public DateTime? DataDevolucao { get; set; }

        [Required]
        public int QuilometragemInicial { get; set; }

        public int? QuilometragemFinal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDiaria { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "EmAndamento";

        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}

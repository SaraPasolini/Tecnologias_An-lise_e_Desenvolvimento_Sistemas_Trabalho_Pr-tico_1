using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosApi.Models
{
    public class Aluguel
    {
        [Key]
        public int AluguelId { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        public DateTime DataDevolucao { get; set; }

        [Required]
        public int KmInicial { get; set; }

        public int KmFinal { get; set; }

        [Required]
        public decimal ValorDiaria { get; set; }

        public decimal ValorTotal { get; set; }

        public Cliente? Cliente { get; set; }
        public Veiculo? Veiculo { get; set; }


    }
}

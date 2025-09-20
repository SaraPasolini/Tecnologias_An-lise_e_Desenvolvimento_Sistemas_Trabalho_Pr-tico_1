using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI
{
    public class Fabricante
    {
        [Key]
        public int IdFabricante { get; set; }


        [Required]
        [MaxLength(100)]
        public string? NomeFabricante { get; set; }


        [MaxLength(50)]
        public string? PaísOrigemFabricante { get; set; }


        public DateTime Criacao { get; set; } = DateTime.UtcNow;

        public ICollection<Veiculo> Veiculos { get; set; }
    }

    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }


        [Required]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }


        [Required]
        [MaxLength(100)]
        public string ModeloVeiculo { get; set; }


        [Required]
        public int AnoVeiculo { get; set; }


        [Required]
        public int QuilometragemVeiculo { get; set; }


        [Required]
        [MaxLength(10)]
        public string PlacaVeiculo { get; set; }

        [Required]
        [MaxLength(10)]
        public string CorVeiculo { get; set; }


        [MaxLength(50)]
        public string StatusVeiculo { get; set; } = "Disponivel";


        public ICollection<Aluguel> Alugueis { get; set; }
    }

    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }


        [Required]
        [MaxLength(150)]
        public string NomeCliente { get; set; }


        [Required]
        [MaxLength(11)]
        public string CPFCliente { get; set; }


        [Required]
        [MaxLength(150)]
        public string EmailCliente { get; set; }


        [MaxLength(20)]
        public string TelefoneCliente { get; set; }


        [MaxLength(250)]
        public string EndereçoCliente { get; set; }


        public ICollection<Aluguel> Alugueis { get; set; }
    }

    public class Aluguel
    {
        [Key]
        public int IdAluguel { get; set; }


        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        [Required]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }


        [Required]
        public DateTime DataInicioAluguel { get; set; }


        [Required]
        public DateTime DataFinalAluguel { get; set; }


        public DateTime? DataDevoluçãoAluguel { get; set; }


        [Required]
        public int QuilometragemInicialAluguel { get; set; }


        public int? QuilometragemFinalAluguel { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDiaria { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }


        [MaxLength(50)]
        public string Status { get; set; } = "EmAndamento";


        public ICollection<Pagamento> Pagamentos { get; set; }
    }

    public class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }


        [Required]
        public int AluguelId { get; set; }
        public Aluguel Aluguel { get; set; }


        public DateTime DataPagamento { get; set; } = DateTime.UtcNow;


        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }


        [MaxLength(50)]
        public string MetódoPagamento { get; set; }
    }

}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosApi.Models
{
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }

        [ForeignKey("Fabricante")]
        public int FabricanteId { get; set; }

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public string Placa { get; set; } = string.Empty;

        [Required]
        public int Ano { get; set; }

        [Required]
        public decimal Quilometragem { get; set; }

        public Fabricante? Fabricante { get; set; }
        public ICollection<Aluguel>? Alugueis { get; set; }

    }
}

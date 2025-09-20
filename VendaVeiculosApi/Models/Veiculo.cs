using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosApi.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public string Placa { get; set; } = string.Empty;

        [Required]
        public string Cor { get; set; } = string.Empty;

        [Required]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; } = new Fabricante();


        public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
    }
}

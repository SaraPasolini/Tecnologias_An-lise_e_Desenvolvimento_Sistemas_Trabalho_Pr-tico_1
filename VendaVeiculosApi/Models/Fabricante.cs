using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendaVeiculosApi.Models
{
    public class Fabricante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Pais { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculosApi.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AluguelId { get; set; }
        public Aluguel Aluguel { get; set; } = new Aluguel();

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public string MetodoPagamento { get; set; } = string.Empty;
    }
}

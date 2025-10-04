using System.ComponentModel.DataAnnotations;
using VeiculosAPI.DTOs;

namespace VendaVeiculosApi.DTOs
{
    public class AluguelDTOs
    {
        public int AluguelId { get; set; }
        
        [Required]
        public int ClienteId { get; set; }
        
        [Required]
        public int VeiculoId { get; set; }
        
        [Required]
        public DateTime DataInicio { get; set; }
        
        [Required]
        public DateTime DataFim { get; set; }
        
        public DateTime? DataDevolucao { get; set; }
        
        [Required]
        public decimal KmInicial { get; set; }
        
        public decimal KmFinal { get; set; }
        
        [Required]
        public decimal ValorDiaria { get; set; }
        
        public decimal ValorTotal { get; set; }
        
        public ClienteDTOs? Cliente { get; set; }
        public VeiculoDTOs? Veiculo { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.DTOs
{
    public class VeiculoDTOs
    {
        public int VeiculoId { get; set; }
        
        [Required]
        public string? Modelo { get; set; }

         [Required]
        public string? Placa { get; set; }

         [Required]
        public string? Cor { get; set; }
        
        [Required]
        public DateTime Ano { get; set; }
        
        [Required]
        public decimal Km { get; set; }
        
        [Required]
        public int FabricanteId { get; set; }
        
        public FabricanteDTOs? Fabricante { get; set; }
    }
}
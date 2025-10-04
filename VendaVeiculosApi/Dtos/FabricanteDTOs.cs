using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.DTOs
{
    public class FabricanteDTOs
    {
        public int FabricanteId { get; set; }

        [Required]
        public string? Nome { get; set; }

        
        [Required]
        public string? Origem { get; set; }
        
        
    }
}
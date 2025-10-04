using System.ComponentModel.DataAnnotations;

namespace VendaVeiculosApi.DTOs
{
    public class ClienteDTOs
    {
        public int ClienteId { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public int CodPessoa { get; set; }

        [Required]
        public string? Cpf { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Telefone { get; set; }
    }
}
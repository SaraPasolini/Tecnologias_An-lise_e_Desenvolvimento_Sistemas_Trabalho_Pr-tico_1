using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendaVeiculosApi.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public int CodPessoa { get; set; } = int.MinValue;

        [Required]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Telefone { get; set; } = string.Empty;

        public ICollection<Aluguel>? Alugueis { get; set; } = new List<Aluguel>();

    }
}

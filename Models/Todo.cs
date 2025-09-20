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


        public DateTime Criação { get; set; } = DateTime.UtcNow;

        public ICollection<Veículo> Veículos { get; set; }
    }

    public class Veiculo
    {
        [Key]
        public int IdVeículo { get; set; }


        [Required]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }


        [Required]
        [MaxLength(100)]
        public string ModeloVeículo { get; set; }


        [Required]
        public int AnoVeículo { get; set; }


        [Required]
        public int QuilometragemVeículo { get; set; }


        [Required]
        [MaxLength(10)]
        public string PlacaVeículo { get; set; }

        [Required]
        [MaxLength(10)]
        public string CorVeículo { get; set; }


        [MaxLength(50)]
        public string StatusVeículo { get; set; } = "Disponivel";


        public ICollection<Aluguel> Alugueis { get; set; }
    }

    
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosApi.Data;
using VendaVeiculosApi.Models;
using VendaVeiculosApi.DTOs;

namespace VendaVeiculosApi.Controllers
{
    [Route("api/alugueis")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AluguelController(AppDbContext context)
        {
            _context = context;
        }

        // GET Geral
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AluguelDTOs>>> GetAlugueis()
        {
            var alugueis = await _context.Aluguei.ToListAsync();
            return Ok(alugueis);
        }

        // GET por id
        [HttpGet("{id}")]
        public async Task<ActionResult<AluguelDTOs>> GetAluguel(int id)
        {
            var aluguel = await _context.Aluguei.FindAsync(id);
            return Ok(aluguel);
        }

         [HttpGet("veiculo/{veiculoId}")]
        public async Task<ActionResult<IEnumerable<AluguelDTOs>>> GetAluguelPorVeiculo(int veiculoId)
        {
            var alugueis = await _context.Aluguei.Where(a => a.VeiculoId == veiculoId).ToListAsync();
            return Ok(alugueis);
        }

        // POST criar
        [HttpPost]
        public async Task<ActionResult<AluguelDTOs>> PostAluguel(AluguelDTOs aluguelDTOs)
        {
            var aluguel = new Aluguel
            {
    
                AluguelId = aluguelDTOs.AluguelId,
                VeiculoId = aluguelDTOs.VeiculoId,
                ClienteId = aluguelDTOs.ClienteId,
                DataInicio = aluguelDTOs.DataInicio,
                DataFim = aluguelDTOs.DataFim,
                ValorTotal = aluguelDTOs.ValorTotal
            };

            _context.Aluguei.Add(aluguel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluguel", new { id = aluguel.AluguelId }, aluguel);
        }

        // PUT atualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(int id, AluguelDTOs aluguelDto)
        {

            var aluguel = await _context.Aluguei.FindAsync(id);
            if (aluguel == null)
                return NotFound();

            aluguel.ClienteId = aluguelDto.ClienteId;
            aluguel.VeiculoId = aluguelDto.VeiculoId;
            aluguel.DataInicio = aluguelDto.DataInicio;
            aluguel.DataFim = aluguelDto.DataFim;
            aluguel.DataDevolucao = aluguelDto.DataDevolucao ?? default(DateTime);
            aluguel.KmInicial = (int)aluguelDto.KmInicial;
            aluguel.KmFinal = (int)aluguelDto.KmFinal;
            aluguel.ValorDiaria = aluguelDto.ValorDiaria;
            aluguel.ValorTotal = aluguelDto.ValorTotal;

            _context.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlugueiExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        // DELETE apagar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluguel(int id)
        {
            var aluguel = await _context.Aluguei.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            _context.Aluguei.Remove(aluguel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlugueiExists(int id)
        {
            return _context.Aluguei.Any(e => e.AluguelId == id);
        }

    }
}
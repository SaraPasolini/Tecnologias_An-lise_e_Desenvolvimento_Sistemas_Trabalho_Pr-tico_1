using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosApi.Data;
using VendaVeiculosApi.Models;

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
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueis()
        {
            var Aluguel = await _context.Aluguei.ToListAsync();
            return Ok(Aluguel);
        }

        // GET por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluguel>> GetAluguel(int id)
        {
            var aluguel = await _context.Aluguei.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }
            return aluguel;
        }

        // GET por veículo
        [HttpGet("por-veiculo/{veiculoId}")]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueisPorVeiculo(int veiculoId)
        {
            var alugueis = await _context.Aluguei
                .Where(a => a.VeiculoId == veiculoId)
                .ToListAsync();

            return Ok(alugueis);
        }

        // POST criar
        [HttpPost]
        public async Task<ActionResult<Aluguel>> PostAluguel(Aluguel aluguel)
        {
            _context.Aluguei.Add(aluguel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluguel), new { id = aluguel.AluguelId }, aluguel);
        }

        // PUT atualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(int id, Aluguel aluguel)
        {
            if (id != aluguel.AluguelId)
            {
                return BadRequest();
            }

            _context.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlugueiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosApi.Data;
using VendaVeiculosApi.Models;


namespace VendaVeiculosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AluguelController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluguel>>> GetAlugueis()
        {
            return await _context.Alugueis
                                 .Include(a => a.Cliente)
                                 .Include(a => a.Veiculo)
                                 .Include(a => a.Pagamentos)
                                 .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluguel>> GetAluguel(int id)
        {
            var aluguel = await _context.Alugueis
                                        .Include(a => a.Cliente)
                                        .Include(a => a.Veiculo)
                                        .Include(a => a.Pagamentos)
                                        .FirstOrDefaultAsync(a => a.Id == id);
            if (aluguel == null) return NotFound();
            return aluguel;
        }

        [HttpPost]
        public async Task<ActionResult<Aluguel>> PostAluguel(Aluguel aluguel)
        {
            _context.Alugueis.Add(aluguel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAluguel), new { id = aluguel.Id }, aluguel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(int id, Aluguel aluguel)
        {
            if (id != aluguel.Id) return BadRequest();

            _context.Entry(aluguel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluguel(int id)
        {
            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel == null) return NotFound();

            _context.Alugueis.Remove(aluguel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
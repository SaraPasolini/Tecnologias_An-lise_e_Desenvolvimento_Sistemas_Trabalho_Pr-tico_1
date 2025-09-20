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
    public class PagamentoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PagamentoController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            return await _context.Pagamentos
                                 .Include(p => p.Aluguel)
                                 .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var pagamento = await _context.Pagamentos
                                          .Include(p => p.Aluguel)
                                          .FirstOrDefaultAsync(p => p.Id == id);
            if (pagamento == null) return NotFound();
            return pagamento;
        }

        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPagamento), new { id = pagamento.Id }, pagamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.Id) return BadRequest();

            _context.Entry(pagamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null) return NotFound();

            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
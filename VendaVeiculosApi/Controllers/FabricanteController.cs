using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosApi.Data;
using VendaVeiculosApi.Models;

namespace VendaVeiculosApi.Controllers
{
    [Route("api/fabricantes")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FabricanteController(AppDbContext context)
        {
            _context = context;
        }

        // GET geral
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricantes()
        {
            return await _context.Fabricante.ToListAsync();
        }

        // GET por id 
        [HttpGet("{id}")]
        public async Task<ActionResult<Fabricante>> GetFabricante(int id)
        {
            var fabricante = await _context.Fabricante.FindAsync(id);

            if (fabricante == null)
            {
                return NotFound();
            }

            return fabricante;
        }

        // Get com veículos
        [HttpGet("pega-veiculos")]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricantespegaVeiculos()
        {
            var fabricantes = await _context.Fabricante.ToListAsync();
            return Ok(fabricantes);
        }

        // Get origem
        [HttpGet("origem/{origem}")]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricantesPorOrigem(string origem)
        {
            var fabricantes = await _context.Fabricante
                .Where(f => f.Origem.Equals(origem, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            return Ok(fabricantes);
        }

        // POST cadastrar
        [HttpPost]
        public async Task<ActionResult<Fabricante>> PostFabricante(Fabricante fabricante)
        {
            _context.Fabricante.Add(fabricante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFabricante", new { id = fabricante.FabricanteId }, fabricante);

        }

        // PUT atualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricante(int id, Fabricante fabricante)
        {
            if (id != fabricante.FabricanteId)
            {
                return BadRequest();
            }

            _context.Entry(fabricante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricanteExists(id))
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

        private bool FabricanteExists(int id)
        {
            return _context.Fabricante.Any(e => e.FabricanteId == id);
        }

        // DELETE apagar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabricante(int id)
        {
            var fabricante = await _context.Fabricante.FindAsync(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            _context.Fabricante.Remove(fabricante);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

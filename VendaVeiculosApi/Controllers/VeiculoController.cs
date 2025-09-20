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
    public class VeiculoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public VeiculoController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.Include(v => v.Fabricante).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.Include(v => v.Fabricante)
                                                .FirstOrDefaultAsync(v => v.Id == id);
            if (veiculo == null) return NotFound();
            return veiculo;
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVeiculo), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id) return BadRequest();

            _context.Entry(veiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) return NotFound();

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

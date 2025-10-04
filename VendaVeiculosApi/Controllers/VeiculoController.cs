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
    [Route("api/veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        // GET geral
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculo.ToListAsync();
        }

        // GET por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        // GET por fabricante
        [HttpGet("por-fabricante/{fabricanteId}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculosPorFabricante(int fabricanteId)
        {
            var veiculos = await _context.Veiculo
                .Where(v => v.FabricanteId == fabricanteId)
                .ToListAsync();

            return Ok(veiculos);
        }

        // Get por placa
        [HttpGet("por-placa/{placa}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoPorPlaca(string placa)
        {
            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        // POST cadastrar
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Veiculo.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVeiculo), new { id = veiculo.VeiculoId }, veiculo);
        }

        // PUT atualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.VeiculoId)
                return BadRequest("ID do veículo não corresponde");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculo.Any(v => v.VeiculoId == id);
        }

        // DELETE remover
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
                return NotFound();

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

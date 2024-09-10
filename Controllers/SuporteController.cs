using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Assist_API.Data;
using Personal_Assist_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal_Assist_API.Controllers
{
    /// <summary>
    /// Controlador para gerenciar suportes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SuporteController : ControllerBase
    {
        private readonly Contexto _context;

        /// <summary>
        /// Construtor para inicializar o contexto do controlador.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public SuporteController(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os suportes.
        /// </summary>
        /// <returns>Uma lista de suportes com as empresas associadas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suporte>>> GetSuportes()
        {
            return await _context.Suportes.Include(s => s.Empresa).ToListAsync();
        }

        /// <summary>
        /// Obtém um suporte específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do suporte.</param>
        /// <returns>O suporte correspondente ao ID, se encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Suporte>> GetSuporte(int id)
        {
            var suporte = await _context.Suportes.Include(s => s.Empresa).FirstOrDefaultAsync(s => s.Id == id);

            if (suporte == null)
            {
                return NotFound();
            }

            return suporte;
        }

        /// <summary>
        /// Adiciona um novo suporte.
        /// </summary>
        /// <param name="suporte">O suporte a ser adicionado.</param>
        /// <returns>O suporte adicionado.</returns>
        [HttpPost]
        public async Task<ActionResult<Suporte>> PostSuporte(Suporte suporte)
        {
            _context.Suportes.Add(suporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSuporte), new { id = suporte.Id }, suporte);
        }

        /// <summary>
        /// Atualiza um suporte existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do suporte a ser atualizado.</param>
        /// <param name="suporte">Os dados atualizados do suporte.</param>
        /// <returns>Uma resposta HTTP sem conteúdo se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuporte(int id, Suporte suporte)
        {
            if (id != suporte.Id)
            {
                return BadRequest();
            }

            _context.Entry(suporte).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove um suporte pelo ID.
        /// </summary>
        /// <param name="id">O ID do suporte a ser removido.</param>
        /// <returns>Uma resposta HTTP sem conteúdo se a remoção for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuporte(int id)
        {
            var suporte = await _context.Suportes.FindAsync(id);
            if (suporte == null)
            {
                return NotFound();
            }

            _context.Suportes.Remove(suporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

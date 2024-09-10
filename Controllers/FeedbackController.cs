using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Assist_API.Data;
using Personal_Assist_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal_Assist_API.Controllers
{
    /// <summary>
    /// Controlador para gerenciar feedbacks.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly Contexto _context;

        /// <summary>
        /// Construtor para inicializar o contexto do controlador.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public FeedbackController(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os feedbacks.
        /// </summary>
        /// <returns>Uma lista de feedbacks com as empresas associadas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            return await _context.Feedbacks.Include(f => f.Empresa).ToListAsync();
        }

        /// <summary>
        /// Obtém um feedback específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do feedback.</param>
        /// <returns>O feedback correspondente ao ID, se encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _context.Feedbacks.Include(f => f.Empresa).FirstOrDefaultAsync(f => f.Id == id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        /// <summary>
        /// Adiciona um novo feedback.
        /// </summary>
        /// <param name="feedback">O feedback a ser adicionado.</param>
        /// <returns>O feedback adicionado.</returns>
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeedback), new { id = feedback.Id }, feedback);
        }

        /// <summary>
        /// Atualiza um feedback existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do feedback a ser atualizado.</param>
        /// <param name="feedback">Os dados atualizados do feedback.</param>
        /// <returns>Uma resposta HTTP sem conteúdo se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove um feedback pelo ID.
        /// </summary>
        /// <param name="id">O ID do feedback a ser removido.</param>
        /// <returns>Uma resposta HTTP sem conteúdo se a remoção for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

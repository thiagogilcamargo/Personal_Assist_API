using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Assist_API.Data;
using Personal_Assist_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal_Assist_API.Controllers
{
    /// <summary>
    /// Controlador para gerenciar serviços.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly Contexto _context;

        /// <summary>
        /// Construtor para inicializar o contexto do controlador.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public ServicoController(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os serviços.
        /// </summary>
        /// <returns>Uma lista de serviços com as empresas associadas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            return await _context.Servicos.Include(s => s.Empresa).ToListAsync();
        }

        /// <summary>
        /// Obtém um serviço específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do serviço.</param>
        /// <returns>O serviço correspondente ao ID, se encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
            var servico = await _context.Servicos.Include(s => s.Empresa).FirstOrDefaultAsync(s => s.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        /// <summary>
        /// Adiciona um novo serviço.
        /// </summary>
        /// <param name="servico">O serviço a ser adicionado.</param>
        /// <returns>O serviço adicionado.</returns>
        [HttpPost]
        public async Task<ActionResult<Servico>> PostServico(Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServico), new { id = servico.Id }, servico);
        }

        /// <summary>
        /// Atualiza um serviço existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do serviço a ser atualizado.</param>
        /// <param name="servico">Os dados atualizados do serviço.</param>
        /// <returns>Uma resposta HTTP sem conteúdo se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, Servico servico)
        {
            if (id != servico.Id)
            {
                return BadRequest();
            }

            _context.Entry(servico).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove um serviço pelo ID.
        /// </summary>
        /// <param name="id">O ID do serviço a ser removido.</param>
        /// <returns>Uma resposta HTTP sem conteúdo se a remoção for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

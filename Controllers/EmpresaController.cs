using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Assist_API.Data;
using Personal_Assist_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal_Assist_API.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações com empresas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly Contexto _context;

        /// <summary>
        /// Inicializa uma nova instância do controlador de Empresa.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public EmpresaController(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de todas as empresas.
        /// </summary>
        /// <returns>Uma lista de objetos Empresa.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        /// <summary>
        /// Retorna uma empresa específica com base no ID.
        /// </summary>
        /// <param name="id">O ID da empresa.</param>
        /// <returns>Um objeto Empresa correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        /// <summary>
        /// Cria uma nova empresa.
        /// </summary>
        /// <param name="empresa">Os dados da nova empresa.</param>
        /// <returns>O objeto Empresa recém-criado.</returns>
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.Id }, empresa);
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        /// <param name="id">O ID da empresa.</param>
        /// <param name="empresa">Os dados atualizados da empresa.</param>
        /// <returns>Uma resposta HTTP com o status de atualização.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Exclui uma empresa específica com base no ID.
        /// </summary>
        /// <param name="id">O ID da empresa a ser excluída.</param>
        /// <returns>Uma resposta HTTP com o status de exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
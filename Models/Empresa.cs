using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Personal_Assist_API.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string CNPJ { get; set; } = string.Empty;

        public List<Servico> Servicos { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Suporte> Suportes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Personal_Assist_API.Models
{
    public class Servico
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
    }
}

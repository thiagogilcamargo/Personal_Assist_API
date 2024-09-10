using System.ComponentModel.DataAnnotations;

namespace Personal_Assist_API.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public string Conteudo { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
    }
}

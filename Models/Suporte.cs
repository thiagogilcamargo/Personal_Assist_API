using System.ComponentModel.DataAnnotations;

namespace Personal_Assist_API.Models
{
    public class Suporte
    {
        public int Id { get; set; }

        [Required]
        public string Detalhes { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
    }
}

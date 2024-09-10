using Microsoft.EntityFrameworkCore;
using Personal_Assist_API.Models;

namespace Personal_Assist_API.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Suporte> Suportes { get; set; }
    }
}

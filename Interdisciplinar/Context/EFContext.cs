
using System.Data.Entity;
using Interdisciplinar.Models;

namespace Interdisciplinar.Contexts
{
    
    public class EFContext: DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") {}

        public DbSet<Ideia> Ideias { get; set; }

        public DbSet<DepartamentoOpet> DepartamentosOpet { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        
    }
}
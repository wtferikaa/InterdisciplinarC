
using System.Data.Entity;
using Interdisciplinar.Models;

namespace Interdisciplinar.Contexts
{

    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Ideia> Ideias { get; set; }

        public DbSet<DepartamentoOpet> DepartamentosOpet { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Curso> Cursos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ideia>()
                .HasOptional<Ideia>(p => p.IdeiaExistente);
        }

    }
}
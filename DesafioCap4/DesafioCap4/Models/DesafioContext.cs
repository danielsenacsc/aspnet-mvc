using System.Data.Entity;

namespace DesafioCap4.Models
{
    public class DesafioContext : DbContext
    {
        public DesafioContext() : base()
        {
            Database.Connection.ConnectionString = @"data source=DANIEL-PC;initial catalog=DesafioCap4BD; Integrated Security=SSPI";
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
    }
}
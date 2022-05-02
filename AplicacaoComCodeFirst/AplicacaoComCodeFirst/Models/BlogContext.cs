using System.Data.Entity;

namespace AplicacaoComCodeFirst.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base()
        {
            Database.Connection.ConnectionString = @"data source=DANIEL-PC;initial catalog=BlogBDLivro; Integrated Security=SSPI";
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}
#region Namespaces
using Microsoft.EntityFrameworkCore;
#endregion



namespace PharmaGo.DAL
{
    public class PGADbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=GPADb;Trusted_Connection=True;");
        }
    }
}

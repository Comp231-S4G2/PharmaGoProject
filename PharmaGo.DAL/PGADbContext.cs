#region Namespaces
using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
#endregion



namespace PharmaGo.DAL
{
    public class PGADbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=GPADb;Trusted_Connection=True;");
        }

        public DbSet<GPAUser> GPAUsers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<StockMedicine> StockMedicines { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}

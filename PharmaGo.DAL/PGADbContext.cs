#region Namespaces
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
#endregion



namespace PharmaGo.DAL
{
    public class PGADbContext:IdentityDbContext
    {
        public PGADbContext()
        {

        }
        public PGADbContext(DbContextOptions<PGADbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
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

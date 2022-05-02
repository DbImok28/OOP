using lab13.Models;
//using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.Entity;

namespace lab13
{
    public class DoctorsDbContext : DbContext
    {
        public DoctorsDbContext()
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //if (!optionsBuilder.IsConfigured)
        //    //{
        //    //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
        //    //}
        //}
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class AgencyContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PacchettoViaggio> PacchettiViaggi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=localhost;Initial Catalog=db-agency;Integrated Security=True";
            // la stringa di connessione si trova selezionando il DB di riferimento e cliccando su proprietà
            optionsBuilder.UseSqlServer(conn);
        }

        public AgencyContext()
        {
        }

        public AgencyContext(DbContextOptions<AgencyContext> options) :base(options)
        {
        }
    }
}

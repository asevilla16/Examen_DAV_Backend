using Examen2_DAV_AngelSevilla.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2_DAV_AngelSevilla.DataContext
{
    public class VaccinationContext : DbContext
    {
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<VaccinationCenter> VaccinationCenters { get; set; }
        public DbSet<VaccinationControl> VaccinationControls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=DESKTOP-C2JN085; DataBase=VaccinationsDB; Trusted_Connection=True;");
        }
    }
}

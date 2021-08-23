using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext () : base("BaseConecction")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Vehiculo> Vehiculo { get; set; }

        public DbSet<Servicios> Servicios { get; set; }

        public DbSet<Vehiculo_Servicio> Vehiculo_Servicio { get; set; }
    }
}

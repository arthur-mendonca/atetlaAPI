using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtetlaAPI.models;
using Microsoft.EntityFrameworkCore;

namespace atetlaAPI.models
{
    public class AtletaContext : DbContext
    {
        private readonly String caminhoDB;
        public DbSet<Atleta> Atletas { get; set; }

        public AtletaContext()
        {
            caminhoDB = $"{AppDomain.CurrentDomain.BaseDirectory}\\atleta.db";
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={caminhoDB}");
        }
    }
}
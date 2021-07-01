using ListaContactos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContactos.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Contactos> Contactos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DataBase/Data.db");
        }
    }
}

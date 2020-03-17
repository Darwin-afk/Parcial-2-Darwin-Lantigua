using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial2_Darwin_Lantigua.Entidades;

namespace Parcial2_Darwin_Lantigua.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database\Parcial2.db");
        }
    }
}

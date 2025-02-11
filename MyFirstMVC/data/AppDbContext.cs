using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Models;

namespace MyFirstMVC.data
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {


        }

        public DbSet<Localizacao> Localizacao {get; set;}

        //Esse método impede a criação de uma nova tabela,
        //usando a tabela já existente.
        protected void OModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Localizacao>().ToTable("Person.Localizacao");

            modelBuilder.Entity<Person>().ToTable("Person.Person");

            modelBuilder.Entity<Multa>().ToTable("Person.multa");

            modelBuilder.Entity<Usuario>().ToTable("Person.Usuario");
        }

        public DbSet<Person> Person {get; set;}

        public DbSet<Multa> Multa {get; set;}

        public DbSet<Usuario> Usuario {get; set;}

        public DbSet<Pagamento> Pagamento {get; set;}

        public DbSet<Departamento> Departamento {get; set;}
    }
}
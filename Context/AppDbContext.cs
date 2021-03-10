using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        public DbSet<Persona> Persona {get; set;}
        public DbSet<Vacuna> Vacuna {get; set;}
    }    
}
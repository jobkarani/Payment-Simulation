using Microsoft.EntityFrameworkCore;
using Payment_Simulation.Models;
using Payment_Simulation.Services;
using System.Reflection.Emit;
using System.Xml;

namespace Payment_Simulation.Data
{
    
    public class TransactionsSimulation: DbContext
    
    {
    
        public TransactionsSimulation(DbContextOptions options) : base(options) { }
     
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    
        {
            modelBuilder.ApplyConfiguration(new TransactionsConfig());
    
        }
    
    }

}
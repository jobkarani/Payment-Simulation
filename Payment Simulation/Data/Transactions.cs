﻿using Microsoft.EntityFrameworkCore;
using Payment_Simulation.Models;
using System.Reflection.Emit;
using System.Xml;

namespace Payment_Simulation.Data
{
    public class TransactionsSimulation: DbContext
    {
        public TransactionsSimulation(DbContextOptions options) : base(options) { }
     
        DbSet<Models.Transactions> Transactions
        {
            get;
            set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionsConfig());
        }
    }
}

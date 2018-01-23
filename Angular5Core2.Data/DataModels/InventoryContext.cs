using Angular5Core2.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Angular5Core2.Data.DataModels
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options) { }
        
        public InventoryContext()
        {
            //var builder = new DbContextOptionsBuilder<InventoryContext>();
            //builder.UseSqlServer("Server=PKS\\MSSQLSERVER2016;Database=InventoryPDB;user id=sa;password=admin123;Trusted_Connection=True;MultipleActiveResultSets=true;");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PKS\\MSSQLSERVER2016;Database=InventoryPDB;user id=sa;password=admin123;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        //public InventoryContext Create(DbContextFactoryOptions opt)
        //{
        //    var builder = new DbContextOptionsBuilder<InventoryContext>();
        //    builder.UseSqlServer("Server=PKS\\MSSQLSERVER2016;Database=InventoryPDB;user id=sa;password=admin123;Trusted_Connection=True;MultipleActiveResultSets=true;");

        //    return new InventoryContext(builder.Options);
        //}

        public DbSet<InventoryMaster> InventoryMaster { get; set; }
               
    }
}

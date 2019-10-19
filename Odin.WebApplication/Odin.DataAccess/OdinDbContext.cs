using Microsoft.EntityFrameworkCore;
using Odin.DataAccess.Extensions;
using Odin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.DataAccess
{
    public class OdinDbContext : DbContext
    {
        public DbSet<ObjectDetected> Detections { get; set; }
        public DbSet<DetectionBatch> Batchs { get; set; }
        public OdinDbContext(DbContextOptions<OdinDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            Seed.SeedData(modelBuilder);
        }
    }
}

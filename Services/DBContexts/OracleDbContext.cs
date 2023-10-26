using Microsoft.EntityFrameworkCore;
using Services.DbDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBContexts
{
    public class OracleDbContext : DbContext
    {

        public DbSet<TaskInfo> Tasks { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<int>("SEQ_TBL_TASK").IncrementsBy(1).HasMin(1).HasMax(2000000).StartsAt(1).IsCyclic();

            modelBuilder.Entity<TaskInfo>(entity =>
            {
                // Set key for entity
                entity.HasKey(t=> t.TASK_ID);
            });

            base.OnModelCreating(modelBuilder);
           

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            base.OnConfiguring(optionsBuilder);
        }
    }
}

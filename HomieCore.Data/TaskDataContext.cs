using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomieCore.Data
{
    public class TaskDataContext: DbContext
    {
        public TaskDataContext(DbContextOptions<TaskDataContext> options):
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Task>()
            // .HasMany(e=>e.Users)
            // .WithMany(e=>e.Tasks)
            // .HasForeignKey("UserAssignedId");
            // modelBuilder.Entity<Task>()
            // .HasMany(e=>e.Users)
            // .WithMany(e=>e.Tasks)
            // .HasForeignKey("UserCreatedId");
        }
        public DbSet<User> Users {get;set;} = null!;
        public DbSet<Group> Groups {get;set;} = null!;
        public DbSet<Task> Tasks {get;set;} =null!;
    }
}
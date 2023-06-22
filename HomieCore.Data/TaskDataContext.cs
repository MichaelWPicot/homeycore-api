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
        }
        public DbSet<User> Users {get;set;} = null!;
        public DbSet<Group> Groups {get;set;} = null!;
        public DbSet<Task> Tasks {get;set;} =null!;
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomieCore.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        public DbSet<User> Users {get;set;} = null!;
        public DbSet<Group> Groups {get;set;} = null!;
        public DbSet<Task> Tasks {get;set;} =null!;
        public DbSet<GroupTask> GroupTask {get;set;} =null!;
        public DbSet<GroupUser> GroupUser {get;set;} =null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<GroupUser>().HasKey(
            gu => new {gu.GroupsId, gu.UsersId}
        );
        modelBuilder.Entity<GroupUser>()
            .HasOne(gu => gu.Group)
            .WithMany(g => g.GroupUsers)
            .HasForeignKey(gu => gu.GroupsId);
         modelBuilder.Entity<GroupUser>()
            .HasOne(gu => gu.User)
            .WithMany(u => u.GroupUsers)
            .HasForeignKey(gu => gu.UsersId);

        modelBuilder.Entity<GroupTask>().HasKey(
            gu => new {gu.GroupsId, gu.TasksId}
        );
        modelBuilder.Entity<GroupTask>()
            .HasOne(gu => gu.Group)
            .WithMany(g => g.GroupTasks)
            .HasForeignKey(gu => gu.GroupsId);
         modelBuilder.Entity<GroupTask>()
            .HasOne(gu => gu.Task)
            .WithMany(u => u.GroupTasks)
            .HasForeignKey(gu => gu.TasksId);

           modelBuilder.Seed();
        }
    }
}
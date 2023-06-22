using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomieCore.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User()
                    {
                        Id=1,
                        FirstName="Jon",
                        LastName="Snow",
                        LastModifiedDateTime=DateTime.UtcNow
                    },
                    new User()
                    {
                        Id=2,
                        FirstName="Clive",
                        LastName="Rosfield",
                        LastModifiedDateTime=DateTime.UtcNow
                    }
            );
            modelBuilder.Entity<Group>().HasData(
                 new Group(){
                        Id =1,
                        GroupName="Night's Watch",
                        GroupDescription="Wasted Potential",
                        LastModifiedTime=DateTime.UtcNow
                    },
                    new Group(){
                        Id =2,
                        GroupName="Rosaria Nobels",
                        GroupDescription="PC Port Is Going To Take So Long",
                        LastModifiedTime=DateTime.UtcNow
                    }
            );
            modelBuilder.Entity<Task>().HasData(
                 new Task(){
                        Id=1,
                        TaskName="Free The North",
                        TaskDescription="You know Nuthin Jon Snow",
                        CompleteByDate=DateTime.UtcNow,
                        TaskCreatedDate=DateTime.UtcNow,
                        LastModifiedDateTime=DateTime.UtcNow,
                        CreatedUserId=1,
                        AssignedUserId=2
                    },
                    new Task(){
                        Id=2,
                        TaskName="Get Revenge",
                        TaskDescription="Will That Really Solve Anything?",
                        CompleteByDate=DateTime.UtcNow,
                        TaskCreatedDate=DateTime.UtcNow,
                        LastModifiedDateTime=DateTime.UtcNow,
                        CreatedUserId=2,
                        AssignedUserId=1,
                    }
            );
            modelBuilder.Entity<GroupTask>().HasData(
            new GroupTask(){
                GroupsId=1,
                TasksId=1
            },
            new GroupTask(){
                GroupsId=2,
                TasksId=2
            }
        );
         modelBuilder.Entity<GroupUser>().HasData(
            new GroupUser(){
                GroupsId=1,
                UsersId=1
            },
            new GroupUser(){
                GroupsId=1,
                UsersId=2
            },
              new GroupUser(){
                GroupsId=2,
                UsersId=1
            },
            new GroupUser(){
                GroupsId=2,
                UsersId=2
            }
        );
        }
    }
}
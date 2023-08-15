using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomieCore.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime LastModifiedDateTime { get; set; }
        public ICollection<GroupUser> GroupUsers { get; set; } = null!;
        [InverseProperty("CreatedUser")]
        public ICollection<Task> CreatedTasks { get; set; } = null!;
        [InverseProperty("AssignedUser")]
        public ICollection<Task> AssignedTasks { get; set; } = null!;
    }
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = null!;
        public string GroupDescription { get; set; } = null!;
        public DateTime LastModifiedTime { get; set; }
        public ICollection<GroupTask> GroupTasks { get; set; } = null!;
         public ICollection<GroupUser> GroupUsers { get; set; } = null!;
    }

    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = null!;
        public string TaskDescription { get; set; } = null!;
        public DateTime CompleteByDate { get; set; }
        public DateTime TaskCreatedDate { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public ICollection<GroupTask> GroupTasks { get; set; } = null!;
        [ForeignKey("CreatedUser")]
        public int? CreatedUserId { get; set; }
        public User? CreatedUser { get; set; }
        [ForeignKey("AssignedUser")]
        public int? AssignedUserId { get; set; }
        public User? AssignedUser
        {
            get; set;
        }
    }
    public class GroupTask{
    public int? GroupsId { get; set; }
    public int TasksId { get; set; }
    public Group Group {get;set;}=null!;
    public Task Task {get;set;}=null!;
    }
    public class GroupUser{
    public int GroupsId { get; set; }
     public Group Group {get;set;} = null!;
    public int UsersId { get; set; }
    public User User {get;set;} = null!;
    }
}
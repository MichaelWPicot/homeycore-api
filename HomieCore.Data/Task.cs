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
        public List<Group> Groups { get; } = new();
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
        public List<Task> Tasks { get; } = new();
        public List<User> Users { get; } = new();
    }

    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = null!;
        public string TaskDescription { get; set; } = null!;
        public DateTime CompleteByDate { get; set; }
        public DateTime TaskCreatedDate { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public List<Group> Groups { get; } = new();
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
}
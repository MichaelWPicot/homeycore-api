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
        public int Id {get; set;}
        public string FirstName {get;set;} = null!;
        public string LastName {get;set;} = null!;
        public DateTime LastModifiedDateTime {get;set;}
        public List<Group> Groups {get;} = new();
        public ICollection<Task> Tasks {get;} = new List<Task>();
    }
    public class Group{
        public int Id {get;set;}
        public string GroupName {get;set;} = null!;
        public string GroupDescription {get;set;} = null!;
        public DateTime LastModifiedTime { get; set; }
        public List<Task> Tasks {get;} = new();
        public List<User> Users {get;} = new();
    }

    public class Task{
        public int Id{get;set;}
        public string TaskName{get;set;} = null!;
        public string TaskDescription{get;set;} = null!;
        public DateTime CompleteByDate { get; set; }
        public DateTime TaskCreatedDate { get; set; }
        public DateTime LastModifiedDateTime{get;set;}
        public List<Group> Groups {get;} =new();

        [ForeignKey("UserCreatedId")]
        public virtual User? UserCreated{get;set;}
        [ForeignKey("UserAssignedId")]
        public virtual User? UserAssigned {get;set;}
    }
}

//  "id": "00000000-0000-0000-0000-000000000000",
//     "firstName": "John",
//     "lastName": "Smith",
//     "lastModifiedDateTime": "2023-06-15T08:00:00",
//     "groups": [
//         "Apartment A",
//         "Apartment B"
//     ]
//   group.Id,
                // group.GroupName,
                // group.GroupDescription,
                // group.Tasks,
                // group.Users,
                // group.LastModifiedTime
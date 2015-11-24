using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace WebApplication.Models
{
    public class Employee
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FullName { get; set; }
        public ICollection<EmploymentHistory> JobAssignments { get; set; }
    }
    public class Department
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class JobRole
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
    public class EmploymentHistory
    {
        public string Company { get; set; }
        public Department Department { get; set; }
        public JobRole JobRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

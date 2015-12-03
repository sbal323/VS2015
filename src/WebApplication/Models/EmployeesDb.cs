using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WebApplication.Models
{
    public class EmployeesDb
    {
        public static MongoCollection<Employee> Open()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var db = server.GetDatabase("Employees");
            return db.GetCollection<Employee>("employees");

        }
    }
}

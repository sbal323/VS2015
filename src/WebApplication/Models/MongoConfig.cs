using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace WebApplication.Models
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var employees = EmployeesDb.Open();
            if (!employees.AsQueryable().Any(x=> x.FullName == "Sergey Balog"))
            {
                var initData = new List<Employee>()
                {
                    new Employee {FullName = "Sergey Balog", 
                        JobAssignments = new List<EmploymentHistory>() {
                            new EmploymentHistory {
                                Company = "SDS",
                                Department = new Department() { Name = "Executive", Country = "Ukraine"},
                                JobRole = new JobRole() { Name = "CTO", Category = "Technical" },
                                StartDate = new DateTime(2002,1,1),
                                EndDate = new DateTime(2008,12,30)
                            },
                            new EmploymentHistory {
                                Company = "Lanteria",
                                Department = new Department() { Name = "Executive", Country = "Ukraine"},
                                JobRole = new JobRole() { Name = "CTO", Category = "Technical" },
                                StartDate = new DateTime(2009,1,1),
                                EndDate = new DateTime(2039,1,1)
                            }
                        }
                    },
                    new Employee {FullName = "Sergey Turin",
                        JobAssignments = new List<EmploymentHistory>() {
                            new EmploymentHistory {
                                Company = "SDS",
                                Department = new Department() { Name = "Executive", Country = "Ukraine"},
                                JobRole = new JobRole() { Name = "CEO", Category = "Technical" },
                                StartDate = new DateTime(2002,1,1),
                                EndDate = new DateTime(2008,12,30)
                            },
                            new EmploymentHistory {
                                Company = "Lanteria",
                                Department = new Department() { Name = "Executive", Country = "Ukraine"},
                                JobRole = new JobRole() { Name = "CEO", Category = "Technical" },
                                StartDate = new DateTime(2009,1,1),
                                EndDate = new DateTime(2039,1,1)
                            }
                        }
                    }
                };
                employees.InsertBatch(initData);
            }
        }
    }
}

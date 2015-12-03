using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MongoDB.Driver;
using WebApplication.Models;
using System.Net.Http;
using MongoDB.Bson;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        MongoCollection<Employee> _employees;
        public EmployeesController()
        {
            _employees = EmployeesDb.Open();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employees.FindAll(); //new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            //return "value";
            var employee = _employees.FindOneById(ObjectId.Parse(id));
            if (employee == null)
            {
                return new HttpNotFoundResult();
            }
            return new JsonResult(employee);
        }

        // GET api/values/5
        [Route("api/employees/{id}/jobrole")]
        public IActionResult GetJobRole(string id)
        {
            //return "value";
            var employee = _employees.FindOneById(ObjectId.Parse(id));
            if (employee == null)
            {
                return new HttpNotFoundResult(); //nullredire
            }
            return new JsonResult( employee.JobAssignments.ToList<EmploymentHistory>()[0].JobRole);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

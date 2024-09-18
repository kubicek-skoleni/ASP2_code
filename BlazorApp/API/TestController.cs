using BlazorApp.Data;
using BlazorApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly PeopleDbContext db;

        public TestController(PeopleDbContext db)
        {
            this.db = db;
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public string Hello(string name) 
        {
            return $"hello {name}";
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<Person> GetPersonById(int id)
        {
            try
            {
                var person = db.People
                    .Include(x => x.Contracts)
                    .Include(x => x.Address)
                    .Where(x => x.Id == id)
                    .Single();
                return person;
            }
            catch (Exception ex) 
            {
                return NotFound();
            }
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleWebApi.Db;

namespace PeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDbContext _peopleDbContext;

        public PeopleController(PeopleDbContext peopleDbContext)
            => this._peopleDbContext = peopleDbContext;

        [HttpGet("ping")]
        public IActionResult Ping() => Ok("pong");

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var people = await this._peopleDbContext.People.ToListAsync();

            return Ok(people);
        }
    }
}
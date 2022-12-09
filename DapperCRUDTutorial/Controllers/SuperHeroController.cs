using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace DapperCRUDTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SuperHeroController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHeroes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")) ;
            var heroes = await connection.QueryAsync<SuperHero>("select * from SuperHeroes");
            return Ok(heroes);

        }
    }
}

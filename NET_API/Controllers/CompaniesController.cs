using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API.Models;

namespace NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        readonly Technical_Test_Context db;

        public CompaniesController(Technical_Test_Context _db)
        {
            db = _db;
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await db.Companies.ToListAsync();
                return Ok(companies);

            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An error occurred while retrieving companies.",
                    error = ex.Message
                });

            }
        }
    }
}

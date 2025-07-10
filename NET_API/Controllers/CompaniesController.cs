using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API.Helpers;
using NET_API.Models;
using NET_Models;

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
                    errors = ex.Message
                });

            }
        }

        [HttpPost("CompanyRegistration")]
        public async Task<IActionResult> CompanyRegistration(CompanyRegistrationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UploadHandler uploadHandler = new UploadHandler();

                var npwpFileName = await uploadHandler.UploadAsync(request.NpwpDocument);
                var attoreyFileName = await uploadHandler.UploadAsync(request.PowerOfAttoreyDocument);

                Company newEntity = new();
                newEntity.Name = request.Name;
                newEntity.Npwp = request.Npwp;
                newEntity.DirectorName = request.DirectorName;
                newEntity.PicName = request.PicName;
                newEntity.Email = request.Email;
                newEntity.PhoneNumber = request.PhoneNumber;
                newEntity.NpwpSrc = npwpFileName;
                newEntity.PowerOfAttoreySrc = attoreyFileName;
                newEntity.InvitationAccess = request.InvitationAccess;
                newEntity.CreatedAt = DateTime.Now;

                await db.AddAsync(newEntity);
                await db.SaveChangesAsync();

                return Ok( new { message = "Registration success", data = newEntity });
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An error occurred while saving record.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload(IFormFile request)
        {
            try
            {
                UploadHandler handler = new UploadHandler();
                var fileName = await handler.UploadAsync(request);
                return Ok(fileName);

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}

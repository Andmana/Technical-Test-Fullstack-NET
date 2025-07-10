using NET_Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NET_MVC.Services
{
    public class CompaniesService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string ROUTE_API = "";

        public CompaniesService(IConfiguration _configuration)
        {
            configuration = _configuration;
            ROUTE_API = configuration["RouteAPI"];
        }

        public async Task<HttpResponseMessage> CompanyRegistrationAsync(CompanyRegistrationRequest model)
        {
            var apiUrl = ROUTE_API +  "api/Companies/CompanyRegistration";

            using var form = new MultipartFormDataContent();
            // Add string fields
            form.Add(new StringContent(model.Name ?? ""), "Name");
            form.Add(new StringContent(model.Npwp ?? ""), "Npwp");
            form.Add(new StringContent(model.DirectorName ?? ""), "DirectorName");
            form.Add(new StringContent(model.PicName ?? ""), "PicName");
            form.Add(new StringContent(model.Email ?? ""), "Email");
            form.Add(new StringContent(model.PhoneNumber ?? ""), "PhoneNumber");
            form.Add(new StringContent(model.InvitationAccess.ToString()), "InvitationAccess");

            // Add NPWP file
            if (model.NpwpDocument != null && model.NpwpDocument.Length > 0)
            {
                var npwpStream = model.NpwpDocument.OpenReadStream();
                var npwpContent = new StreamContent(npwpStream);
                npwpContent.Headers.ContentType = new MediaTypeHeaderValue(model.NpwpDocument.ContentType);
                form.Add(npwpContent, "NpwpDocument", model.NpwpDocument.FileName);
            }

            // Add Power of Attorney file
            if (model.PowerOfAttoreyDocument != null && model.PowerOfAttoreyDocument.Length > 0)
            {
                var attStream = model.PowerOfAttoreyDocument.OpenReadStream();
                var attContent = new StreamContent(attStream);
                attContent.Headers.ContentType = new MediaTypeHeaderValue(model.PowerOfAttoreyDocument.ContentType);
                form.Add(attContent, "PowerOfAttoreyDocument", model.PowerOfAttoreyDocument.FileName);
            }

            return await client.PostAsync(apiUrl, form);
        }
    }
}

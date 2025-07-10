using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NET_Models
{
    public class CompanyRegistrationRequest
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NPWP is required.")]
        public string Npwp { get; set; }

        [Required(ErrorMessage = "Director name is required.")]
        public string DirectorName { get; set; }

        [Required(ErrorMessage = "PIC name is required.")]
        public string PicName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "NPWP document is required.")]
        public IFormFile NpwpDocument { get; set; }

        [Required(ErrorMessage = "Power of Attorney document is required.")]
        public IFormFile PowerOfAttoreyDocument { get; set; }

        public bool InvitationAccess { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NET_API.Helpers
{
    public class UploadHandler
    {
        private readonly string[] _allowedExtensions = new[] { ".pdf" };
        private const long MaxFileSize = 1 * 1024 * 1024; // 1MB

        public async Task<string> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("File is empty or missing.");

            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!_allowedExtensions.Contains(extension))
                throw new Exception("Only PDF files are allowed.");

            if (file.Length > MaxFileSize)
                throw new Exception("Maximum file size is 1MB.");

            // Generate unique filename
            string fileName = Guid.NewGuid().ToString() + extension;
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            string fullPath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Optionally return a relative or virtual path
            return fileName;
        }
    }
}

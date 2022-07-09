using Microsoft.AspNetCore.Http;

namespace Psychology.ViewModels
{
    public class LecturerAddTestViewModel
    {
        public string Message { get; set; }
        public IFormFile Path { get; set; }
    }
}

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AvatarsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("getAvatar")]
        public IActionResult GetAvatar(string name)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string avatarPath = Path.Combine(webRootPath, "Images/Avatars", name);
            if (!System.IO.File.Exists(avatarPath))
            {
                return NotFound();
            }
            var image = System.IO.File.OpenRead(avatarPath);
            return File(image, "image/png");
        }
    }
}

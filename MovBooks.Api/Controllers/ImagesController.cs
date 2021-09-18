using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImagesController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Authorize]
        [Route("uploadImage")]
        public IActionResult UploadImage([FromQuery] string folder)
        {
            try
            {
                var files = _httpContextAccessor.HttpContext.Request.Form.Files;
                if (files.Count() != 0)
                {
                    string imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", folder);
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + files[0].FileName;
                    string filePath = Path.Combine(imageFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    return Ok(new { uniqueFileName });
                }
                else
                {
                    return BadRequest(new { message = "No files found!" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex });
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("deleteImage")]
        public IActionResult DeleteImage([FromQuery] string filename, [FromQuery] string folder)
        {
            try
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", folder, filename);
                if (!System.IO.File.Exists(imagePath))
                {
                    return BadRequest(new { message = "Image Not Found!" });
                }
                else
                {
                    System.IO.File.Delete(imagePath);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex });
            }
        }

        [HttpGet]
        [Route("getImage")]
        public IActionResult GetImage([FromQuery] string filename, [FromQuery] string folder)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string imagePath = Path.Combine(webRootPath, "Images", folder, filename);
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }
            string extension = Path.GetExtension(imagePath).Substring(1);
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, $"image/{ extension }");
        }
    }
}

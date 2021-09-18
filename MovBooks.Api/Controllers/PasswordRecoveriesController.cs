using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using MovBooks.Infrastructure.Interfaces;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoveriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IPasswordRecoveryService _passwordRecoveryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PasswordRecoveriesController(
            IMapper mapper,
            IMailService mailService,
            IWebHostEnvironment webHostEnvironment,
            IPasswordRecoveryService passwordRecoveryService
        )
        {
            _mapper = mapper;
            _passwordRecoveryService = passwordRecoveryService;
            _webHostEnvironment = webHostEnvironment;
            _mailService = mailService;
        }

        // GET: api/PasswordRecoveries
        [HttpGet]
        public IActionResult GetPasswordRecoveries([FromQuery] PasswordRecoveryQueryFilter filters)
        {
            var passRecoveries = _passwordRecoveryService.GetAll(filters);
            var passRecoveriesDto = _mapper.Map<IEnumerable<PasswordRecoveryDto>>(passRecoveries);

            var metadata = new Metadata
            {
                TotalCount = passRecoveries.TotalCount,
                PageSize = passRecoveries.PageSize,
                CurrentPage = passRecoveries.CurrentPage,
                TotalPages = passRecoveries.TotalPages,
                HasNextPage = passRecoveries.HasNextPage,
                HasPreviousPage = passRecoveries.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<PasswordRecoveryDto>>(passRecoveriesDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // GET: api/PasswordRecoveries?token=GUID
        [HttpGet]
        [Route("find")]
        public async Task<IActionResult> GetPasswordRecovery([FromQuery] string token)
        {
            var passRecovery = await _passwordRecoveryService.FindByToken(token);
            if (passRecovery == null)
            {
                return NotFound(new { message = "Token incorrecto" });
            }
            var passRecoveryDto = _mapper.Map<PasswordRecoveryDto>(passRecovery);
            var response = new ApiResponse<PasswordRecoveryDto>(passRecoveryDto);
            return Ok(response);
        }

        // POST: api/PasswordRecoveries
        [HttpPost]
        public async Task<IActionResult> PostPasswordRecovery(PasswordRecoveryDto passwordRecoveryDto)
        {
            // Eliminar todos los passwordRecovery del mismo email
            await _passwordRecoveryService.DeleteRange(passwordRecoveryDto.Email);

            // Almacenar nuevo Password Recovery
            var passwordRecovery = _mapper.Map<PasswordRecovery>(passwordRecoveryDto);
            await _passwordRecoveryService.Insert(passwordRecovery);

            passwordRecoveryDto = _mapper.Map<PasswordRecoveryDto>(passwordRecovery);
            var response = new ApiResponse<PasswordRecoveryDto>(passwordRecoveryDto);

            // Enviar correo electrónico
            string webRootPath = _webHostEnvironment.WebRootPath;
            string htmlTemplatePath = Path.Combine(webRootPath, "HTMLTemplates/template.html");

            // Enviar código al correo electrónico
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(htmlTemplatePath))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{token}", passwordRecovery.Token);
            _mailService.SendEmail(passwordRecovery.Email, "Recuperación de contraseña", body);

            return Ok(response);
        }
    }
}

using Infrastructure.Application.Interfaces;
using Infrastructure.DTOs;
using Infrastructure.Model;

using Microsoft.AspNetCore.Mvc;

namespace SignsBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaFirmasController : ControllerBase
    {
        private readonly ISingularPointService _service;
        private readonly IWebHostEnvironment _env;

        public PruebaFirmasController(IWebHostEnvironment env, ISingularPointService service)
        {
            _env = env;
            _service = service;
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSingularPointDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("El archivo es obligatorio.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.File.FileName);
            var fullPath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            // Enviar solo la ruta relativa al servicio
            var filePathRelative = $"uploads/{fileName}";
            await _service.CreateSingularPointAsync(dto, filePathRelative);

            return Ok("Guardado correctamente");
        }


    }
}

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
        public async Task<IActionResult> Create([FromForm] CreateSingularPointDto dto)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            await _service.CreateSingularPointAsync(dto, uploadsFolder);
            return Ok();
        }

    }
}

using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Model;
using Microsoft.AspNetCore.Mvc;

namespace SignsBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.AddAsync(usuario);
            await _unitOfWork.SaveAsync();
            return Ok(usuario);
        }
    }
}

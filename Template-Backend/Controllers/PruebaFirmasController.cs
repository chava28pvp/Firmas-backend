using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Model;
using Microsoft.AspNetCore.Mvc;

namespace SignsBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaFirmasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PruebaFirmasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("assign-file")]
        public async Task<IActionResult> AssignFile([FromBody] AssignFileRequest request)
        {
            var singularPoint = await _unitOfWork.SingularPointRepository.GetByIdAsync(request.IdSingularPoint);

            if (singularPoint == null)
                return NotFound("Singular Point not found.");

            var archive = new ArchiveUrls
            {
                PathFile = request.PathFile,
                IdSingularPoint = request.IdSingularPoint
            };

            await _unitOfWork.ArchiveUrlsRepository.AddAsync(archive);

            // Actualizar el Singular Point
            singularPoint.LastUpdateDate = DateTime.UtcNow;
            _unitOfWork.SingularPointRepository.Update(singularPoint);

            // Guardar todo en una sola transacción
            await _unitOfWork.SaveAsync();

            return Ok("Archivo asignado correctamente.");
        }
        public class AssignFileRequest
        {
            public int IdSingularPoint { get; set; }
            public string PathFile { get; set; }
        }

    }
}

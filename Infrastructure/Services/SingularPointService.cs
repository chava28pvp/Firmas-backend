using Infrastructure.Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.DTOs;
using Infrastructure.Model;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SingularPointService : ISingularPointService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SingularPointService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateSingularPointAsync(CreateSingularPointDto dto, string uploadsFolder)
        {
            // 1. Guardar archivo físicamente
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.File.FileName);
            var fullPath = Path.Combine(uploadsFolder, fileName);

            Directory.CreateDirectory(uploadsFolder); // Crea carpeta si no existe

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            // 2. Crear entidad SingularPoint
            var singularPoint = new SingularPoint
            {
                Name = dto.Name,
                Description = dto.Description,
                WiwUpload = dto.WiwUpload,
                IdTypesArchive = dto.IdTypesArchive,
                Active = true,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                ArchiveUrls = new List<ArchiveUrls>
        {
            new ArchiveUrls
            {
                PathFile = $"uploads/{fileName}"
            }
        }
            };

            // 3. Guardar en base de datos
            await _unitOfWork.SingularPoints.AddAsync(singularPoint);
            await _unitOfWork.CompleteAsync();
        }


    }


}

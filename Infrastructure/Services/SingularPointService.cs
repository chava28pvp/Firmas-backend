using Infrastructure.Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.DTOs;
using Infrastructure.Model;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
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

        public async Task CreateSingularPointAsync(CreateSingularPointDto dto, string pathFile)
        {
            var singularPoint = new SingularPoint
            {
                Name = dto.Name,
                Description = dto.Description,
                WiwUpload = dto.WiwUpload,
                Active = dto.Active,
                CreationDate = dto.CreationDate,
                LastUpdateDate = dto.LastUpdateDate,
                ArchiveUrls = new List<ArchiveUrls>
        {
            new ArchiveUrls
            {
                PathFile = pathFile
            }
        }
            };

            await _unitOfWork.SingularPoints.AddAsync(singularPoint);
            await _unitOfWork.CompleteAsync();
        }



    }


}

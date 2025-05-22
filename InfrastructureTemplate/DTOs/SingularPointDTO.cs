using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTemplate.DTOs
{
    public class CreateSingularPointDto
    {
        public string Name { get; set; } = string.Empty;
        public string WiwUpload { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int IdTypesArchive { get; set; }
        public IFormFile File { get; set; } = null;
    }
}

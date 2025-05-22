using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    public class CreateSingularPointDto
    {
        public string Name { get; set; }
        public string WiwUpload { get; set; }
        public string Description { get; set; }
        public int IdTypesArchive { get; set; }
        public IFormFile File { get; set; } = null;
    }
}

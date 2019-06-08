using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string DocumentType { get; set; }
    }
}

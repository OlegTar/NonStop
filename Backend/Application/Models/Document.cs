using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public byte[] Image { get; set; }
        public int DocumentId { get; set; }
        public int DocumentTypeId { get; set;}
        public DocumentType DocumentType { get; set; }
    }
}

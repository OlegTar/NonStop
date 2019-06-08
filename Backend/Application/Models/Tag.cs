using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public Specialization Specialization { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SpecializationSubject
    {
        public int Id { get; set; }
        public Univercity Univercity { get; set; }
        public Specialization Specialization { get; set; }
        public Subject Subject { get; set; }

    }
}

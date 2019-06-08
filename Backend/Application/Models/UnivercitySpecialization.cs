using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UnivercitySpecialization
    {
        public int UnivercityId { get; set; }
        public Univercity Univercity { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}

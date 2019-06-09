using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Univercity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }

        public int MinScore { get; set; }
        public int AverageScore { get; set; }
        public IList<Specialization> Specializations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PointsBySubject
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Subject Subject { get; set; }
        public int NumberOfPoints { get; set; }
    }
}

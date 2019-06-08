using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int UnivercityId { get; set; }
        public string Comment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Request
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Univercity Univercity { get; set; }
        public Specialization Specialization { get; set; }
        public RequestStatus Status { get; set; }
        public string Comment { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PatronymicName { get; set; }
        public DateTime BirthDate { get; set; }
        public Univercity Univercity { get; set; }

        public IList<Document> Documents { get; set; }
        public string IdInOAuthProvider { get; set; }
        public string Avatar { get; set; }
        public string SessionId { get; set; }
    }
}

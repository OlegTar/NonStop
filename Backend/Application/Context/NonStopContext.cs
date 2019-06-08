using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Context
{
    public class NonStopContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=NonStop;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UnivercitySpecialization>()
                .HasKey(us => new { us.UnivercityId, us.SpecializationId });

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Univercity> Univercities { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Request> Requests { get; set; }
        public DbSet<PointsBySubject> PointsBySubjects { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Document> Documents { get; set; }

    }
}

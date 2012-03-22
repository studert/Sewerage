using System;
using System.Data.Entity;

namespace Sewerage.Models
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Observation> Observations { get; set; }
    }

    #region Test Data
    public partial class AppDbContext
    {
        static AppDbContext()
        {
            Database.SetInitializer(new TestDataInitializer());
        }

        private class TestDataInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
        {
            protected override void Seed(AppDbContext context)
            {
                var p1 = new Project { Name = "Project 1", Description = "Project 1 Description" }; context.Projects.Add(p1);
                context.SaveChanges();

                var s1 = new Section { Number = 1, Project = p1 }; context.Sections.Add(s1);

                var i1 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s1 }; context.Inspections.Add(i1);
                var i2 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s1 }; context.Inspections.Add(i2);

                context.Observations.Add(new Observation {Description = "Observation 1", Inspection = i1});
                context.Observations.Add(new Observation {Description = "Observation 2", Inspection = i1});
                context.Observations.Add(new Observation {Description = "Observation 3", Inspection = i1});
                context.Observations.Add(new Observation {Description = "Observation 4", Inspection = i2});
                context.Observations.Add(new Observation {Description = "Observation 5", Inspection = i2});
            }
        }
    }
    #endregion
}
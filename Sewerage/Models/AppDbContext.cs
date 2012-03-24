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
                var p2 = new Project { Name = "Project 2", Description = "Project 2 Description" }; context.Projects.Add(p2);
                context.SaveChanges();

                var s1 = new Section { Number = 1, Project = p1 }; context.Sections.Add(s1);
                var s2 = new Section { Number = 2, Project = p1 }; context.Sections.Add(s2);
                var s3 = new Section { Number = 1, Project = p2 }; context.Sections.Add(s3);
                var s4 = new Section { Number = 2, Project = p2 }; context.Sections.Add(s4);

                var i1 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s1 }; context.Inspections.Add(i1);
                var i2 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s1 }; context.Inspections.Add(i2);
                var i3 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s2 }; context.Inspections.Add(i3);
                var i4 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s2 }; context.Inspections.Add(i4);
                var i5 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s3 }; context.Inspections.Add(i5);
                var i6 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s3 }; context.Inspections.Add(i6);
                var i7 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s4 }; context.Inspections.Add(i7);
                var i8 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s4 }; context.Inspections.Add(i8);

                context.Observations.Add(new Observation {Description = "Observation 1", Inspection = i1});
                context.Observations.Add(new Observation {Description = "Observation 2", Inspection = i1});
                context.Observations.Add(new Observation {Description = "Observation 3", Inspection = i1});
                context.Observations.Add(new Observation {Description = "Observation 4", Inspection = i2});
                context.Observations.Add(new Observation { Description = "Observation 5", Inspection = i2 });
                context.Observations.Add(new Observation { Description = "Observation 6", Inspection = i3 });
                context.Observations.Add(new Observation { Description = "Observation 7", Inspection = i3 });
                context.Observations.Add(new Observation { Description = "Observation 8", Inspection = i4 });
                context.Observations.Add(new Observation { Description = "Observation 9", Inspection = i4 });
                context.Observations.Add(new Observation { Description = "Observation 10", Inspection = i4 });
                context.Observations.Add(new Observation { Description = "Observation 11", Inspection = i5 });
                context.Observations.Add(new Observation { Description = "Observation 12", Inspection = i5 });
                context.Observations.Add(new Observation { Description = "Observation 13", Inspection = i5 });
                context.Observations.Add(new Observation { Description = "Observation 14", Inspection = i6 });
                context.Observations.Add(new Observation { Description = "Observation 15", Inspection = i6 });
                context.Observations.Add(new Observation { Description = "Observation 16", Inspection = i7 });
                context.Observations.Add(new Observation { Description = "Observation 17", Inspection = i7 });
                context.Observations.Add(new Observation { Description = "Observation 18", Inspection = i8 });
                context.Observations.Add(new Observation { Description = "Observation 19", Inspection = i8 });
                context.Observations.Add(new Observation { Description = "Observation 20", Inspection = i8 });
            }
        }
    }
    #endregion
}
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
                var s5 = new Section { Number = 3, Project = p2 }; context.Sections.Add(s5);

                var i1 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s1, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i1);
                var i2 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s1, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i2);
                var i3 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s2, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i3);
                var i4 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s2, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i4);
                var i5 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s3, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i5);
                var i6 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s3, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i6);
                var i7 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s4, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i7);
                var i8 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s4, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i8);
                var i9 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Section = s5, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i9);
                var i10 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s5, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i10);

                context.Observations.Add(new Observation { Description = "Observation 1", Inspection = i1, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 2", Inspection = i1, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 3", Inspection = i1, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 4", Inspection = i2, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 5", Inspection = i2, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 6", Inspection = i3, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 7", Inspection = i3, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 8", Inspection = i4, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 9", Inspection = i4, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 10", Inspection = i4, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 11", Inspection = i5, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 12", Inspection = i5, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 13", Inspection = i5, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 14", Inspection = i6, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 15", Inspection = i6, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 16", Inspection = i7, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 17", Inspection = i7, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 18", Inspection = i8, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 19", Inspection = i8, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 20", Inspection = i8, SecondsIntoVideo = 80 });
                context.Observations.Add(new Observation { Description = "Observation 21", Inspection = i9, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 22", Inspection = i10, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 23", Inspection = i10, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 24", Inspection = i10, SecondsIntoVideo = 50 });
            }
        }
    }
    #endregion
}
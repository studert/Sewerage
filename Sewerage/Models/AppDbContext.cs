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
                //var p3 = new Project { Name = "Project 3", Description = "Project 3 Description" }; context.Projects.Add(p3);
                //var p4 = new Project { Name = "Project 4", Description = "Project 4 Description" }; context.Projects.Add(p4);
                //var p5 = new Project { Name = "Project 5", Description = "Project 5 Description" }; context.Projects.Add(p5);
                //var p6 = new Project { Name = "Project 6", Description = "Project 6 Description" }; context.Projects.Add(p6);
                context.SaveChanges();

                var s1 = new Section { Number = 1, City = "Murten", Street = "Irisweg", Length = 37.3, Project = p1 }; context.Sections.Add(s1);
                var s2 = new Section { Number = 2, City = "Murten", Street = "Irisweg", Length = 21.5, Project = p1 }; context.Sections.Add(s2);
                var s3 = new Section { Number = 1, City = "Brugg", Street = "Steinackerstrasse", Length = 42.4, Project = p2 }; context.Sections.Add(s3);
                var s4 = new Section { Number = 2, City = "Brugg", Street = "Steinackerstrasse", Length = 22.7, Project = p2 }; context.Sections.Add(s4);
                var s5 = new Section { Number = 3, City = "Brugg", Street = "Steinackerstrasse", Length = 13.9, Project = p2 }; context.Sections.Add(s5);

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

                context.Observations.Add(new Observation { Description = "Observation 1", Position = 0, Tag = "BCDXP", Inspection = i1, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 2", Position = 10, Tag = "BAFAE", Inspection = i1, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 3", Position = 20, Tag = "BBCC", Inspection = i1, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 4", Position = 0, Tag = "BBFA", Inspection = i2, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 5", Position = 20, Tag = "BCDXP", Inspection = i2, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 6", Position = 30, Tag = "BCDXP", Inspection = i3, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 7", Position = 60, Tag = "BBFA", Inspection = i3, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 8", Position = 0, Tag = "BCDXP", Inspection = i4, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 9", Position = 30, Tag = "BCDXP", Inspection = i4, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 10", Position = 40, Tag = "BAFBA", Inspection = i4, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 11", Position = 0, Tag = "ABFAE", Inspection = i5, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 12", Position = 10, Tag = "BCDXP", Inspection = i5, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 13", Position = 40, Tag = "BAFBA", Inspection = i5, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 14", Position = 0, Tag = "QCEXP", Inspection = i6, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 15", Position = 50, Tag = "BCDXP", Inspection = i6, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 16", Position = 0, Tag = "BCDXP", Inspection = i7, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 17", Position = 30, Tag = "BBCC", Inspection = i7, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 18", Position = 0, Tag = "BCFXP", Inspection = i8, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 19", Position = 60, Tag = "BAFBA", Inspection = i8, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 20", Position = 80, Tag = "BCDXP", Inspection = i8, SecondsIntoVideo = 80 });
                context.Observations.Add(new Observation { Description = "Observation 21", Position = 0, Tag = "BCDXP", Inspection = i9, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 22", Position = 0, Tag = "BCQXP", Inspection = i10, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 23", Position = 30, Tag = "BBCC", Inspection = i10, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 24", Position = 50, Tag = "BCDXP", Inspection = i10, SecondsIntoVideo = 50 });
            }
        }
    }
    #endregion
}
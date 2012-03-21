using System;
using System.Collections.Generic;
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
                //var o1 = new Observation { Description = "Observation 1" }; context.Observations.Add(o1);
                //var o2 = new Observation { Description = "Observation 2" }; context.Observations.Add(o2);
                //var o3 = new Observation { Description = "Observation 3" }; context.Observations.Add(o3);
                //var o4 = new Observation { Description = "Observation 4" }; context.Observations.Add(o4);
                //var o5 = new Observation { Description = "Observation 5" }; context.Observations.Add(o5);

                //var i1 = new Inspection { StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(8), Observations = new List<Observation> { o1, o2, o3 } }; context.Inspections.Add(i1);
                //var i2 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Observations = new List<Observation> { o4, o5 } }; context.Inspections.Add(i2);
                ////context.SaveChanges();

                //var s1 = new Section { Number = 1, Inspections = new List<Inspection> { i1, i2 } }; context.Sections.Add(s1);
                ////context.SaveChanges();

                //context.Projects.Add(new Project {Description = "Project 1", Sections = new List<Section> {s1}});
                //context.SaveChanges();
            }
        }
    }
    #endregion
}
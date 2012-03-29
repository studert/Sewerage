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
                var p3 = new Project { Name = "Project 3", Description = "Project 3 Description" }; context.Projects.Add(p3);
                var p4 = new Project { Name = "Project 4", Description = "Project 4 Description" }; context.Projects.Add(p4);
                var p5 = new Project { Name = "Project 5", Description = "Project 5 Description" }; context.Projects.Add(p5);
                var p6 = new Project { Name = "Project 6", Description = "Project 6 Description" }; context.Projects.Add(p6);
                var p7 = new Project { Name = "Project 7", Description = "Project 7 Description" }; context.Projects.Add(p7);
                var p8 = new Project { Name = "Project 8", Description = "Project 8 Description" }; context.Projects.Add(p8);
                var p9 = new Project { Name = "Project 9", Description = "Project 9 Description" }; context.Projects.Add(p9);
                var p10 = new Project { Name = "Project 10", Description = "Project 10 Description" }; context.Projects.Add(p10);
                context.SaveChanges();

                var s1 = new Section { Number = 1, City = "Murten", Street = "Irisweg", Length = 37.3, Project = p1 }; context.Sections.Add(s1);
                var s2 = new Section { Number = 2, City = "Murten", Street = "Irisweg", Length = 54.3, Project = p1 }; context.Sections.Add(s2);
                var s3 = new Section { Number = 3, City = "Murten", Street = "Irisweg", Length = 84, Project = p1 }; context.Sections.Add(s3);
                var s4 = new Section { Number = 1, City = "Zürich", Street = "Steinackerstrasse", Length = 984, Project = p2 }; context.Sections.Add(s4);
                var s5 = new Section { Number = 2, City = "Zürich", Street = "Steinackerstrasse", Length = 37.3, Project = p2 }; context.Sections.Add(s5);
                var s6 = new Section { Number = 3, City = "Zürich", Street = "Steinackerstrasse", Length = 44.4, Project = p2 }; context.Sections.Add(s6);
                var s7 = new Section { Number = 4, City = "Zürich", Street = "Steinackerstrasse", Length = 37.2, Project = p2 }; context.Sections.Add(s7);
                var s8 = new Section { Number = 1, City = "Bern", Street =  "Könizweg", Length = 37.3, Project = p3 }; context.Sections.Add(s8);
                var s9 = new Section { Number = 2, City = "Bern", Street =  "Könizweg", Length = 223.3, Project = p3 }; context.Sections.Add(s9);
                var s10 = new Section { Number = 3, City = "Bern", Street = "Könizweg", Length = 37.3, Project = p3 }; context.Sections.Add(s10);
                var s11 = new Section { Number = 4, City = "Bern", Street = "Könizweg", Length = 17.3, Project = p3 }; context.Sections.Add(s11);
                var s12 = new Section { Number = 5, City = "Bern", Street = "Könizweg", Length = 27.3, Project = p3 }; context.Sections.Add(s12);
                var s13 = new Section { Number = 1, City = "Luzern", Street = "Gabelweg", Length = 45.3, Project = p4 }; context.Sections.Add(s13);
                var s14 = new Section { Number = 2, City = "Luzern", Street = "Gabelweg", Length = 30.3, Project = p4 }; context.Sections.Add(s14);
                var s15 = new Section { Number = 1, City = "Lausanne", Street = "Milackerstrasse", Length = 37.3, Project = p5 }; context.Sections.Add(s15);
                var s16 = new Section { Number = 2, City = "Lausanne", Street = "Milackerstrasse", Length = 33.3, Project = p5 }; context.Sections.Add(s16);
                var s17 = new Section { Number = 3, City = "Lausanne", Street = "Milackerstrasse", Length = 21.5, Project = p5 }; context.Sections.Add(s17);
                var s18 = new Section { Number = 4, City = "Lausanne", Street = "Milackerstrasse", Length = 42.4, Project = p5 }; context.Sections.Add(s18);
                var s19 = new Section { Number = 5, City = "Lausanne", Street = "Milackerstrasse", Length = 22.7, Project = p5 }; context.Sections.Add(s19);
                var s20 = new Section { Number = 1, City = "Olten", Street = "Pertolozzistrasse", Length = 13.9, Project = p6 }; context.Sections.Add(s20);
                var s21 = new Section { Number = 2, City = "Olten", Street = "Pertolozzistrasse", Length = 35.3, Project = p6 }; context.Sections.Add(s21);
                var s22 = new Section { Number = 3, City = "Olten", Street = "Pertolozzistrasse", Length = 37.3, Project = p6 }; context.Sections.Add(s22);
                var s23 = new Section { Number = 4, City = "Olten", Street = "Pertolozzistrasse", Length = 34.8, Project = p6 }; context.Sections.Add(s23);
                var s24 = new Section { Number = 5, City = "Olten", Street = "Pertolozzistrasse", Length = 27.3, Project = p6 }; context.Sections.Add(s24);
                var s25 = new Section { Number = 6, City = "Olten", Street = "Pertolozzistrasse", Length = 17.3, Project = p6 }; context.Sections.Add(s25);
                var s26 = new Section { Number = 1, City = "Genf", Street = "Rütenenweg", Length = 35.3, Project = p7 }; context.Sections.Add(s26);
                var s27 = new Section { Number = 2, City = "Genf", Street = "Rütenenweg", Length = 67.3, Project = p7 }; context.Sections.Add(s27);
                var s28 = new Section { Number = 3, City = "Genf", Street = "Rütenenweg", Length = 36.3, Project = p7 }; context.Sections.Add(s28);
                var s29 = new Section { Number = 4, City = "Genf", Street = "Rütenenweg", Length = 39.4, Project = p7 }; context.Sections.Add(s29);
                var s30 = new Section { Number = 1, City = "St. Gallen", Street = "Hauptstrasse", Length = 37.3, Project = p8 }; context.Sections.Add(s30);
                var s31 = new Section { Number = 2, City = "St. Gallen", Street = "Hauptstrasse", Length = 24.3, Project = p8 }; context.Sections.Add(s31);
                var s32 = new Section { Number = 3, City = "St. Gallen", Street = "Hauptstrasse", Length = 65.3, Project = p8 }; context.Sections.Add(s32);
                var s33 = new Section { Number = 1, City = "Basel", Street = "St. Jakobs Allee", Length = 56.3, Project = p9 }; context.Sections.Add(s33);
                var s34 = new Section { Number = 2, City = "Basel", Street = "St. Jakobs Allee", Length = 37.8, Project = p9 }; context.Sections.Add(s34);
                var s35 = new Section { Number = 3, City = "Basel", Street = "St. Jakobs Allee", Length = 37.7, Project = p9 }; context.Sections.Add(s35);
                var s36 = new Section { Number = 4, City = "Basel", Street = "St. Jakobs Allee", Length = 45.3, Project = p9 }; context.Sections.Add(s36);
                var s37 = new Section { Number = 5, City = "Basel", Street = "St. Jakobs Allee", Length = 21.5, Project = p9 }; context.Sections.Add(s37);
                var s38 = new Section { Number = 1, City = "Biel", Street = "Im Hudrien", Length = 42.4, Project = p10 }; context.Sections.Add(s38);
                var s39 = new Section { Number = 2, City = "Biel", Street = "Im Hudrien", Length = 22.7, Project = p10 }; context.Sections.Add(s39);
                var s40 = new Section { Number = 3, City = "Biel", Street = "Im Hudrien", Length = 13.9, Project = p10 }; context.Sections.Add(s40);

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
                var i11 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s6, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i11);
                var i12 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s7, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i12);
                var i13 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s8, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i13);
                var i14 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s9, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i14);
                var i15 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s10, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i15);
                var i16 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s11, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i16);
                var i17 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s12, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i17);
                var i18 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s13, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i18);
                var i19 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s14, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i19);
                var i20 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s15, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i20);
                var i21 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s16, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i21);
                var i22 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s17, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i22);
                var i23 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s18, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i23);
                var i24 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s19, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i24);
                var i25 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s20, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i25);
                var i26 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s21, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i26);
                var i27 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s22, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i27);
                var i28 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s23, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i28);
                var i29 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s24, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i29);
                var i30 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s25, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i30);
                var i31 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s26, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i31);
                var i32 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s27, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i32);
                var i33 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s28, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i33);
                var i34 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s29, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i34);
                var i35 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s30, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i35);
                var i36 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s31, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i36);
                var i37 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s32, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i37);
                var i38 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s33, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i38);
                var i39 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s34, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i39);
                var i40 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s35, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i40);
                var i41 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s36, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i41);
                var i42 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s37, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i42);
                var i43 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s38, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i43);
                var i44 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s39, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i44);
                var i45 = new Inspection { StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Section = s40, VideoUrl = "e544f140-f4ef-4eff-8aad-fe674d5b46ba.ism" }; context.Inspections.Add(i45);

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
                context.Observations.Add(new Observation { Description = "Observation 25", Position = 50, Tag = "BCDXP", Inspection = i10, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 26", Position = 0, Tag = "BCDXP", Inspection = i11, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 27", Position = 10, Tag = "BAFAE", Inspection = i11, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 28", Position = 20, Tag = "BBCC", Inspection = i11, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 29", Position = 0, Tag = "BBFA", Inspection = i12, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 30", Position = 20, Tag = "BCDXP", Inspection = i12, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 31", Position = 30, Tag = "BCDXP", Inspection = i13, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 32", Position = 60, Tag = "BBFA", Inspection = i13, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 33", Position = 0, Tag = "BCDXP", Inspection = i14, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 34", Position = 30, Tag = "BCDXP", Inspection = i14, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 35", Position = 40, Tag = "BAFBA", Inspection = i14, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 36", Position = 0, Tag = "ABFAE", Inspection = i15, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 37", Position = 10, Tag = "BCDXP", Inspection = i15, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 38", Position = 40, Tag = "BAFBA", Inspection = i15, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 39", Position = 0, Tag = "QCEXP", Inspection = i16, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 40", Position = 50, Tag = "BCDXP", Inspection = i16, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 41", Position = 0, Tag = "BCDXP", Inspection = i17, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 42", Position = 30, Tag = "BBCC", Inspection = i17, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 43", Position = 0, Tag = "BCFXP", Inspection = i18, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 44", Position = 60, Tag = "BAFBA", Inspection = i18, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 45", Position = 80, Tag = "BCDXP", Inspection = i18, SecondsIntoVideo = 80 });
                context.Observations.Add(new Observation { Description = "Observation 46", Position = 0, Tag = "BCDXP", Inspection = i19, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 47", Position = 0, Tag = "BCQXP", Inspection = i20, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 48", Position = 30, Tag = "BBCC", Inspection = i20, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 49", Position = 50, Tag = "BCDXP", Inspection = i20, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 50", Position = 50, Tag = "BCDXP", Inspection = i20, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 51", Position = 0, Tag = "BCDXP", Inspection = i21, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 52", Position = 10, Tag = "BAFAE", Inspection = i21, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 53", Position = 20, Tag = "BBCC", Inspection = i21, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 54", Position = 0, Tag = "BBFA", Inspection = i22, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 55", Position = 20, Tag = "BCDXP", Inspection = i22, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 56", Position = 30, Tag = "BCDXP", Inspection = i23, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 57", Position = 60, Tag = "BBFA", Inspection = i23, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 58", Position = 0, Tag = "BCDXP", Inspection = i24, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 59", Position = 30, Tag = "BCDXP", Inspection = i24, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 60", Position = 40, Tag = "BAFBA", Inspection = i24, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 61", Position = 0, Tag = "ABFAE", Inspection = i25, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 62", Position = 10, Tag = "BCDXP", Inspection = i25, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 63", Position = 40, Tag = "BAFBA", Inspection = i25, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 64", Position = 0, Tag = "QCEXP", Inspection = i26, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 65", Position = 50, Tag = "BCDXP", Inspection = i26, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 66", Position = 0, Tag = "BCDXP", Inspection = i27, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 67", Position = 30, Tag = "BBCC", Inspection = i27, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 68", Position = 0, Tag = "BCFXP", Inspection = i28, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 69", Position = 60, Tag = "BAFBA", Inspection = i28, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 70", Position = 80, Tag = "BCDXP", Inspection = i28, SecondsIntoVideo = 80 });
                context.Observations.Add(new Observation { Description = "Observation 71", Position = 0, Tag = "BCDXP", Inspection = i29, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 72", Position = 0, Tag = "BCQXP", Inspection = i30, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 73", Position = 30, Tag = "BBCC", Inspection = i30, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 74", Position = 50, Tag = "BCDXP", Inspection = i30, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 75", Position = 50, Tag = "BCDXP", Inspection = i30, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 76", Position = 0, Tag = "BCDXP", Inspection = i31, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 77", Position = 10, Tag = "BAFAE", Inspection = i31, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 78", Position = 20, Tag = "BBCC", Inspection = i31, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 79", Position = 0, Tag = "BBFA", Inspection = i32, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 80", Position = 20, Tag = "BCDXP", Inspection = i32, SecondsIntoVideo = 20 });
                context.Observations.Add(new Observation { Description = "Observation 81", Position = 30, Tag = "BCDXP", Inspection = i33, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 82", Position = 60, Tag = "BBFA", Inspection = i33, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 83", Position = 0, Tag = "BCDXP", Inspection = i34, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 84", Position = 30, Tag = "BCDXP", Inspection = i34, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 85", Position = 40, Tag = "BAFBA", Inspection = i34, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 86", Position = 0, Tag = "ABFAE", Inspection = i35, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 87", Position = 10, Tag = "BCDXP", Inspection = i35, SecondsIntoVideo = 10 });
                context.Observations.Add(new Observation { Description = "Observation 88", Position = 40, Tag = "BAFBA", Inspection = i35, SecondsIntoVideo = 40 });
                context.Observations.Add(new Observation { Description = "Observation 89", Position = 0, Tag = "QCEXP", Inspection = i36, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 90", Position = 50, Tag = "BCDXP", Inspection = i36, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 91", Position = 30, Tag = "BBCC", Inspection = i37, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 92", Position = 0, Tag = "BCFXP", Inspection = i38, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 93", Position = 60, Tag = "BAFBA", Inspection = i38, SecondsIntoVideo = 60 });
                context.Observations.Add(new Observation { Description = "Observation 94", Position = 80, Tag = "BCDXP", Inspection = i39, SecondsIntoVideo = 80 });
                context.Observations.Add(new Observation { Description = "Observation 95", Position = 0, Tag = "BCDXP", Inspection = i40, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 96", Position = 0, Tag = "BCQXP", Inspection = i41, SecondsIntoVideo = 0 });
                context.Observations.Add(new Observation { Description = "Observation 97", Position = 30, Tag = "BBCC", Inspection = i42, SecondsIntoVideo = 30 });
                context.Observations.Add(new Observation { Description = "Observation 98", Position = 50, Tag = "BCDXP", Inspection = i43, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 99", Position = 50, Tag = "BCDXP", Inspection = i44, SecondsIntoVideo = 50 });
                context.Observations.Add(new Observation { Description = "Observation 100", Position = 0, Tag = "BCDXP", Inspection = i45, SecondsIntoVideo = 0 });
            }
        }
    }
    #endregion
}
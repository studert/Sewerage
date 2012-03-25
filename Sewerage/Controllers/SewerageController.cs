using System.Linq;
using System.Web.Http.Data.EntityFramework;
using Sewerage.Models;

namespace Sewerage.Controllers
{
    public class SewerageController : DbDataController<AppDbContext>
    {
        public IQueryable<Project> GetProjects()
        {
            return DbContext.Projects
                .OrderBy(x => x.Name);
        }

        public IQueryable<Section> GetProjectSections(int projectId)
        {
            return DbContext.Sections
                .Where(x => x.ProjectId == projectId)
                .OrderBy(x => x.Number);
        }

        public IQueryable<Inspection> GetSectionInspections(int sectionId)
        {
            return DbContext.Inspections
                .Where(x => x.SectionId == sectionId)
                .OrderBy(x => x.StartDate);
        }

        public IQueryable<Observation> GetInspectionObservations(int inspectionId)
        {
            return DbContext.Observations
                .Where(x => x.InspectionId == inspectionId)
                .OrderBy(x => x.ObservationId);
        }
    }
}

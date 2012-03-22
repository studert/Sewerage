using System.Linq;
using System.Web.Http.Data.EntityFramework;
using Sewerage.Models;

namespace Sewerage.Controllers
{
    public class DataServiceController : DbDataController<AppDbContext>
    {
        public IQueryable<Observation> GetObservations()
        {
            return DbContext.Observations.Include("Inspection").OrderBy(x => x.ObservationId);
        }

        public void InsertProject(Project project) { InsertEntity(project); }
        public void UpdateProject(Project project) { UpdateEntity(project); }
        public void DeleteProject(Project project) { DeleteEntity(project); }
    }
}

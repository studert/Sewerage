[assembly: WebActivator.PreApplicationStartMethod(typeof(Sewerage.App_Start.ElmahMvc), "Start")]
namespace Sewerage.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}
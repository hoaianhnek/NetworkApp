using NetworkDataAccess;
using System.Linq;
using System.Web.Http;

namespace WebService.Controllers
{
    [RoutePrefix("webservice/api")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public IHttpActionResult Index()
        {
            using(DBNetworkEntities entities = new DBNetworkEntities())
            {
                return Ok(entities.tests.ToList());
            }
            
        }
    }
}

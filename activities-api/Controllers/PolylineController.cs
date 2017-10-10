using activities_api.Services;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace activities_api.Controllers
{
  [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
  public class PolylineController : ApiController
  {
    private PolylineService polylineService;

    public PolylineController()
    {
      this.polylineService = new PolylineService();
    }

    public IHttpActionResult Get()
    {
      var rides = this.polylineService.GetPolylines("Ride").ToList();
      var runs = this.polylineService.GetPolylines("Run").ToList();
      return this.Ok(new { rides = rides, runs = runs });
    }

  }
}

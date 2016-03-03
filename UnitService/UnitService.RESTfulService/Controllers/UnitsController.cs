namespace UnitService.RESTfulService.Controllers
{
    using System.Web.Http;

    using Logic.Directors;

    [RoutePrefix("api")]
    public class UnitsController : ApiController
    {
        private readonly IGetUnitsDirector getUnitsDirector;

        public UnitsController(IGetUnitsDirector getUnitsDirector)
        {
            this.getUnitsDirector = getUnitsDirector;
        }

        [Route("units")]
        public IHttpActionResult GetAll()
        {
            return this.Ok(this.getUnitsDirector.GetUnits());
        }
    }
}
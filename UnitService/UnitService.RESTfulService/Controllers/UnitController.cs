namespace UnitService.RESTfulService.Controllers
{
    using System.Web.Http;

    using Logic.Directors;

    public class UnitController : ApiController
    {
        private readonly IGetUnitsDirector getUnitsDirector;

        public UnitController(IGetUnitsDirector getUnitsDirector)
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
namespace UnitService.RESTfulService.Controllers
{
    using System.Web.Http;

    using Logic.Directors;

    using Logic.Domain;

    /// <summary>
    /// The Units endpoints.
    /// </summary>
    [RoutePrefix("api")]
    public class UnitsController : ApiController
    {
        private readonly IGetUnitsDirector getUnitsDirector;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitsController"/> class. 
        /// </summary>
        /// <param name="getUnitsDirector">
        /// The director responsible for getting all the units.
        /// </param>
        public UnitsController(IGetUnitsDirector getUnitsDirector)
        {
            this.getUnitsDirector = getUnitsDirector;
        }

        /// <summary>
        /// Gets all the units.
        /// </summary>
        /// <returns><see cref="UnitDto"/>Collection of UnitDtos</returns>
        [Route("units")]
        public IHttpActionResult GetAll()
        {
            return this.Ok(this.getUnitsDirector.GetUnits());
        }
    }
}
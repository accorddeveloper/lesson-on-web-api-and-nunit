namespace UnitService.UnitTests.Service.UnitsControllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Results;

    using NSubstitute;

    using NUnit.Framework;

    using RESTfulService.Controllers;

    using UnitService.Logic.Directors;
    using UnitService.Logic.Domain;

    [TestFixture]
    public class GetAll
    {
        private UnitsController controller;

        private IHttpActionResult result;

        [OneTimeSetUp]
        public void Run()
        {
            this.Arrange();
            this.Act();
        }

        public void Arrange()
        {
            var director = Substitute.For<IGetUnitsDirector>();
            controller = new UnitsController(director);
        }

        public void Act()
        {
            this.result = this.controller.GetAll();
        }

        [Test]
        public void AssertResultType()
        {
            var type = typeof(OkNegotiatedContentResult<IEnumerable<UnitDto>>);
            Assert.That(this.result, Is.TypeOf(type));
        }
    }
}
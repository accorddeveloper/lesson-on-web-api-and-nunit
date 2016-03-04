namespace UnitService.UnitTests.Service.UnitsControllers
{
    using System.Web.Http;
    using System.Web.Http.Results;

    using NSubstitute;

    using NUnit.Framework;

    using RESTfulService.Controllers;

    using UnitService.Logic.Directors;
    using UnitService.Logic.Domain;

    [TestFixture(Category = "Service")]
    public class GetUnitByReference
    {
        private const string ReferenceName = "Test";
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
            director.GetUnitByReference(ReferenceName).Returns(new UnitDto());
            controller = new UnitsController(director);
        }

        public void Act()
        {
            this.result = this.controller.GetByReference(ReferenceName);
        }

        [Test]
        public void AssertResultUnitDto()
        {
            var type = typeof(OkNegotiatedContentResult<UnitDto>);
            Assert.That(this.result, Is.TypeOf(type));
        }
    }
}
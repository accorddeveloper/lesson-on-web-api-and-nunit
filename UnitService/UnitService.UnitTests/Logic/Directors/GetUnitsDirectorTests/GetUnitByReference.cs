namespace UnitService.UnitTests.Logic.Directors.GetUnitsDirectorTests
{
    using NSubstitute;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Data.Repositories;
    using UnitService.Logic.Directors;
    using UnitService.Logic.Domain;
    using UnitService.Logic.Mappers;

    [TestFixture(Category = "Directors")]
    public class GetUnitByReference
    {
        private const string UnitName = "Test";

        private GetUnitsDirector director;

        private UnitDto unitDto;

        private UnitDto result;

        private Unit unit;

        [OneTimeSetUp]
        public void Run()
        {
            this.Arrange();
            this.Act();
        }

        public void Arrange()
        {
            var mapper = Substitute.For<IUnitMapper>();
            var repository = Substitute.For<IUnitsRepository>();

            unit = new Unit();
            repository.GetUnitByName(UnitName).Returns(this.unit);

            this.unitDto = new UnitDto();
            mapper.Map(this.unit).Returns(this.unitDto);

            director = new GetUnitsDirector(mapper, repository);
        }

        public void Act()
        {
            result = this.director.GetUnitByReference(UnitName);
        }

        [Test]
        public void AssertSelectedUnitDto()
        {
            Assert.That(this.result, Is.EqualTo(this.unitDto));
        }
    }
}
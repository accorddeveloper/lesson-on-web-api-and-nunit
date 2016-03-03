namespace UnitService.UnitTests.Logic.Directors.GetUnitsDirectorTests
{
    using System.Collections.Generic;
    using System.Linq;

    using NSubstitute;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Data.Repositories;
    using UnitService.Logic.Directors;
    using UnitService.Logic.Domain;
    using UnitService.Logic.Mappers;

    [TestFixture]
    public class GetUnits
    {
        private GetUnitsDirector director;

        private UnitDto unitDtoOne;

        private UnitDto unitDtoTwo;

        private IEnumerable<UnitDto> result;

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
            var units = new List<Unit> { new Unit(), new Unit() };
            repository.GetAllUnitsWithPeople().Returns(units);
            unitDtoOne = new UnitDto();
            unitDtoTwo = new UnitDto();
            mapper.Map(units.First()).Returns(this.unitDtoOne);
            mapper.Map(units.Skip(1).First()).Returns(this.unitDtoTwo);
            director = new GetUnitsDirector(mapper, repository);
        }

        public void Act()
        {
            result = this.director.GetUnits();
        }

        [Test]
        public void AssertFirstUnit()
        {
            Assert.That(this.result.First(), Is.EqualTo(this.unitDtoOne));
        }

        [Test]
        public void AssertSecondUnit()
        {
            Assert.That(this.result.Skip(1).First(), Is.EqualTo(this.unitDtoTwo));
        }
    }
}
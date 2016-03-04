namespace UnitService.UnitTests.Logic.Mappers.UnitMapperTests
{
    using NSubstitute;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Logic.Domain;
    using UnitService.Logic.Mappers;

    [TestFixture(Category = "Mappers")]
    public class MapUnitWithNoPeople
    {
        private Unit unit;

        private UnitMapper mapper;

        private UnitDto dto;

        private IPersonMapper personMapper;

        [OneTimeSetUp]
        public void Run()
        {
            this.Arrange();
            this.Act();
        }

        public void Arrange()
        {
            unit = new Unit { Name = "Empty unit" };

            personMapper = Substitute.For<IPersonMapper>();
            this.mapper = new UnitMapper(this.personMapper);
        }

        public void Act()
        {
            dto = mapper.Map(unit);
        }

        [Test]
        public void AssertUnitReference()
        {
            Assert.That(dto.Reference, Is.EqualTo("Empty unit"));
        }

        [Test]
        public void AssertNoPeopleInEmptyUnit()
        {
            Assert.That(dto.People, Is.Empty);
        }

        [Test]
        public void AssertPersonMapperWasntInvokedOnEmptyCollection()
        {
            this.personMapper.DidNotReceive().Map(Arg.Any<Person>());
        }
    }
}
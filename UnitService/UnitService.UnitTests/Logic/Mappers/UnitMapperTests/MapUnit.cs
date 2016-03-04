namespace UnitService.UnitTests.Logic.Mappers.UnitMapperTests
{
    using System.Collections.Generic;
    using System.Linq;

    using NSubstitute;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Logic.Domain;
    using UnitService.Logic.Mappers;

    [TestFixture(Category = "Mappers")]
    public class MapUnit
    {
        private Unit unit;

        private UnitMapper mapper;

        private UnitDto dto;

        private IPersonMapper personMapper;

        private Person person;

        private PersonDto personDto;

        private PersonDto secondPersonDto;

        private Person secondPerson;

        [OneTimeSetUp]
        public void Run()
        {
            this.Arrange();
            this.Act();
        }

        public void Arrange()
        {
            person = new Person();
            secondPerson = new Person();
            personDto = new PersonDto();
            secondPersonDto = new PersonDto();

            personMapper = Substitute.For<IPersonMapper>();
            this.mapper = new UnitMapper(this.personMapper);

            unit = new Unit { Name = "Ref", People = new List<Person>() };
            this.unit.People.Add(person);
            this.unit.People.Add(this.secondPerson);

            this.personMapper.Map(this.person).Returns(this.personDto);
            this.personMapper.Map(this.secondPerson).Returns(this.secondPersonDto);
        }

        public void Act()
        {
            dto = mapper.Map(unit);
        }

        [Test]
        public void AssertUnitReference()
        {
            Assert.That(dto.Reference, Is.EqualTo("Ref"));
        }

        [Test]
        public void AssertFirstPersonMapped()
        {
            Assert.That(dto.People.First(), Is.EqualTo(this.personDto));
        }

        [Test]
        public void AssertSecondPersonMapped()
        {
            Assert.That(dto.People.Skip(1).First(), Is.EqualTo(this.secondPersonDto));
        }
    }
}
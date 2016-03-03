namespace UnitService.UnitTests.Logic.Mappers.PersonMapperTests
{
    using System;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Logic.Domain;
    using UnitService.Logic.Mappers;

    [TestFixture]
    public class MapPerson
    {
        private Person person;

        private PersonMapper mapper;

        private PersonDto dto;

        [OneTimeSetUp]
        public void Run()
        {
            this.Arrange();
            this.Act();
        }

        public void Arrange()
        {
            person = new Person
            {
                FirstName = "John",
                LastName = "Test",
                DateOfBirth = new DateTime(1980, 2, 24)
            };

            mapper = new PersonMapper();
        }

        public void Act()
        {
            dto = this.mapper.Map(this.person);
        }

        [Test]
        public void AssertFirstName()
        {
            Assert.That(dto.FirstName, Is.EqualTo("John"));
        }

        [Test]
        public void AssertLastName()
        {
            Assert.That(dto.LastName, Is.EqualTo("Test"));
        }

        [Test]
        public void AssertDateOfBirth()
        {
            Assert.That(dto.DateOfBirth, Is.EqualTo(new DateTime(1980, 2, 24)));
        }
    }
}
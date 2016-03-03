namespace UnitService.UnitTests.Data.UnitsRepositoryTests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Data.Repositories;

    [TestFixture]
    public class GetAllUnitsWithPeople
    {
        private FakeUnitServiceContext context;

        private UnitsRepository repository;

        private IEnumerable<Unit> units;

        private Unit unit1;

        private Unit unit2;

        private Person person;

        [OneTimeSetUp]
        public void Arrange()
        {
            person = new Person();

            unit1 = new Unit { People = new Collection<Person>() };
            unit2 = new Unit { People = new Collection<Person>() };

            unit1.People.Add(person);

            context = new FakeUnitServiceContext();
            this.context.Units.Add(unit1);
            this.context.Units.Add(unit2);

            this.Act();
        }

        public void Act()
        {
            repository = new UnitsRepository(this.context);
            units = this.repository.GetAllUnitsWithPeople();
        }

        [Test]
        public void AssertUnitOne()
        {
            Assert.That(units.First(), Is.EqualTo(this.unit1));
        }

        [Test]
        public void AssertUnitTwo()
        {
            Assert.That(units.Skip(1).First(), Is.EqualTo(this.unit2));
        }

        [Test]
        public void AssertPersonIsPresentInUnitOne()
        {
            Assert.That(units.First().People.First(), Is.EqualTo(this.person));
        }

        [Test]
        public void AssertNoPersonIsPresentInUnitTwo()
        {
            Assert.IsEmpty(units.Skip(1).First().People);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this.context.Dispose();
        }
    }
}
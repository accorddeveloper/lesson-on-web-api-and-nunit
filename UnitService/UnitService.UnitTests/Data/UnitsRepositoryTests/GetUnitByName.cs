namespace UnitService.UnitTests.Data.UnitsRepositoryTests
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Data.Repositories;

    [TestFixture(Category = "Data")]
    public class GetUnitByName
    {
        private FakeUnitServiceContext context;

        private UnitsRepository repository;

        private Unit unit;

        private Unit unit1;

        private Unit unit2;

        private Person person;

        [OneTimeSetUp]
        public void Run()
        {
            this.Arrange();
            this.Act();
        }

        public void Arrange()
        {
            person = new Person();

            unit1 = new Unit { People = new Collection<Person>(), Name = "Unit 0" };
            unit2 = new Unit { People = new Collection<Person>(), Name = "Unit 1" };

            unit2.People.Add(person);

            context = new FakeUnitServiceContext();
            this.context.Units.Add(unit1);
            this.context.Units.Add(unit2);

            this.Act();
        }

        public void Act()
        {
            repository = new UnitsRepository(this.context);
            this.unit = this.repository.GetUnitByName("Unit 1");
        }

        [Test]
        public void AssertSelectedUnit()
        {
            Assert.That(this.unit, Is.EqualTo(this.unit2));
        }

        [Test]
        public void AssertPersonIsPresentInSelectedUnit()
        {
            Assert.That(this.unit.People.First(), Is.EqualTo(this.person));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this.context.Dispose();
        }
    }
}
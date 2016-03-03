﻿namespace UnitService.UnitTests.Logic.Directors.GetUnitsDirectorTests
{
    using System;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using UnitService.Data.Database;
    using UnitService.Data.Repositories;
    using UnitService.Logic.Directors;
    using UnitService.Logic.Domain;
    using UnitService.Logic.Mappers;

    [TestFixture]
    public class GetUnitByNameNotFound
    {
        private const string UnitName = "Test";

        private GetUnitsDirector director;

        private UnitDto result;

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

            repository.GetUnitByName(UnitName).Returns((Unit)null);
            mapper.Map(null).Throws(new NullReferenceException());

            director = new GetUnitsDirector(mapper, repository);
        }

        public void Act()
        {
            result = this.director.GetUnitByReference(UnitName);
        }

        [Test]
        public void AssertSelectedUnitIsNull()
        {
            Assert.That(this.result, Is.Null);
        }
    }
}
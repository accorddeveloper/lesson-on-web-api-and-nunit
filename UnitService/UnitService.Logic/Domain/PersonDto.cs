namespace UnitService.Logic.Domain
{
    using System;

    public class PersonDto
    {
        public Titles Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
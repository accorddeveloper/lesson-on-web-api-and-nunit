namespace UnitService.Logic.Domain
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "person")]
    public class PersonDto
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "dob")]
        public DateTime DateOfBirth { get; set; }
    }
}
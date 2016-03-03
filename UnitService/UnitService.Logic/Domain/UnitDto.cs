namespace UnitService.Logic.Domain
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "unit")]
    public class UnitDto
    {
        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "people")]
        public ICollection<PersonDto> People { get; set; }
    }
}
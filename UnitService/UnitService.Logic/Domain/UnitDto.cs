namespace UnitService.Logic.Domain
{
    using System.Collections.Generic;

    public class UnitDto
    {
        public string Reference { get; set; }

        public ICollection<PersonDto> People { get; set; }
    }
}
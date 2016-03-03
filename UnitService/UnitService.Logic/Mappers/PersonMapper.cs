namespace UnitService.Logic.Mappers
{
    using UnitService.Data.Database;
    using UnitService.Logic.Domain;

    public class PersonMapper : IPersonMapper
    {
        public PersonDto Map(Person entity)
        {
            return new PersonDto
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth
            };
        }
    }
}
namespace UnitService.Logic.Mappers
{
    using System.Collections.ObjectModel;

    using UnitService.Data.Database;
    using UnitService.Logic.Domain;

    public class UnitMapper : IUnitMapper
    {
        private readonly IPersonMapper personMapper;

        public UnitMapper(IPersonMapper personMapper)
        {
            this.personMapper = personMapper;
        }

        public UnitDto Map(Unit entity)
        {
            var dto = new UnitDto { Reference = entity.Name, People = new Collection<PersonDto>() };

            if (entity.People == null || entity.People.Count == 0)
            {
                return dto;
            }

            foreach (var person in entity.People)
            {
                dto.People.Add(this.personMapper.Map(person));
            }
            return dto;
        }
    }
}
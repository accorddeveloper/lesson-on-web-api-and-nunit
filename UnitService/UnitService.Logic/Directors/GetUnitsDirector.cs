namespace UnitService.Logic.Directors
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Repositories;
    using Domain;
    using Mappers;

    public class GetUnitsDirector : IGetUnitsDirector
    {
        private readonly IUnitMapper mapper;

        private readonly IUnitsRepository repository;

        public GetUnitsDirector(IUnitMapper mapper, IUnitsRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public IEnumerable<UnitDto> GetUnits()
        {
            var units = this.repository.GetAllUnitsWithPeople();
            return units.Select(entity => this.mapper.Map(entity));
        }

        public UnitDto GetUnitByReference(string reference)
        {
            var entity = this.repository.GetUnitByName(reference);
            return entity != null ? this.mapper.Map(entity) : null;
        }
    }
}
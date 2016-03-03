namespace UnitService.Data.Repositories
{
    using System.Collections.Generic;

    using UnitService.Data.Database;

    public interface IUnitsRepository
    {
        IEnumerable<Unit> GetAllUnitsWithPeople();

        Unit GetUnitByName(string name);
    }
}
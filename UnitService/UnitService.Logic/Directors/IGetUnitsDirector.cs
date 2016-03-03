namespace UnitService.Logic.Directors
{
    using System.Collections.Generic;

    using UnitService.Logic.Domain;

    public interface IGetUnitsDirector
    {
        IEnumerable<UnitDto> GetUnits();
    }
}
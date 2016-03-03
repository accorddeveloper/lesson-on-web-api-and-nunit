namespace UnitService.Logic.Mappers
{
    using UnitService.Data.Database;
    using UnitService.Logic.Domain;

    public interface IUnitMapper
    {
        UnitDto Map(Unit entity);
    }
}
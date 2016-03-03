namespace UnitService.Logic.Mappers
{
    using UnitService.Data.Database;
    using UnitService.Logic.Domain;

    public interface IPersonMapper
    {
        PersonDto Map(Person entity);
    }
}
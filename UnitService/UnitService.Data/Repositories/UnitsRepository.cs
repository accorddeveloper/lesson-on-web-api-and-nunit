namespace UnitService.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Database;

    public class UnitsRepository : IUnitsRepository
    {
        private readonly IUnitServiceContext context;

        public UnitsRepository(IUnitServiceContext context)
        {
            this.context = context;
        }

        public IEnumerable<Unit> GetAllUnitsWithPeople()
        {
            return this.context.Units.Include(u => u.People).ToArray();
        }  
    }
}
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class ThingRepositoryInSQL:IThingRepository
    {
        public ThingRepositoryInSQL() { } //конструктор класса

        public IThing GetThing(int ThingId) { return null; }

        public void AddThing(IThing thing) { }
    }
}

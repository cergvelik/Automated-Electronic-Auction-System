

namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IThingRepository
    {
        IThing GetThing(int ThingId);

        void AddThing(IThing thing);  

    }
}

﻿using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class ThingRepositoryInSQL:IThingRepository
    {
        private readonly string _connectionString;

        public ThingRepositoryInSQL(string connection) { _connectionString = connection; } //конструктор класса

        public IThing GetThing(int ThingId) { return null; }

        public void AddThing(IThing thing) { }
    }
}

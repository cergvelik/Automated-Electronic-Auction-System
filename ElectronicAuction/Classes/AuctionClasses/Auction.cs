﻿using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;


namespace ElectronicAuction.Classes.AuctionClasses
{
    abstract class Auction //пришлось все-таки использовать абстрактный класс чтобы создавать уникальный id аукциона
    {
        private static int _id = 10000;
        public int AuctionId { get; } //Уникальное Id аукциона

        public DateTime StartDate { get; } //Дата начала аукциона
        public DateTime EndDate { get; } //Дата окончания аукциона

        public IUser AuctionCreator { get; }//Создатель аукциона 

        public Auction(IUser Creator)//Все аукционы длятся 2 недели
        {
            AuctionId = ++_id;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(14);
            AuctionCreator = Creator;
        }

    }
}
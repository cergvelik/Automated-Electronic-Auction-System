using ElectronicAuction.Interfaces;

namespace ElectronicAuction.Classes
{
    public class Thing:IThing
    {
        private static int _id = 0;
        public int ThingId { get; }// уникальное Id вещи
        public string Title { get; } //название вещи
        public string Description { get; } //описание вещи
        public decimal StartPrice { get; } //стартовая цена

        public Thing(string title, string description, decimal startPrice)
        {
            ThingId = ++_id;
            Title = title;
            Description = description;
            StartPrice = startPrice;
        }
    }
}

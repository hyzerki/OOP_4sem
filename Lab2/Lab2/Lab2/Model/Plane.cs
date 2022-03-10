namespace Lab1.Model
{
    public enum PlaneType
    {
        Passenger, Cargo, Military
    }
    internal class Plane
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public PlaneType Type { get; set; }
        public int PassengerSeats { get; set; }
        public int ReleasedAt { get; set; }
        public int Capatity { get; set; }
        public DateTime LastMaintenance { get; set; }
        public List<CrewMate> CrewList { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public Plane(Guid id, string model, PlaneType type, int passengerSeats, int releasedAt, int capatity, DateTime lastMaintenance, List<CrewMate> crewList, Manufacturer manufacturer)
        {
            Id = id;
            Model = model;
            Type = type;
            PassengerSeats = passengerSeats;
            ReleasedAt = releasedAt;
            Capatity = capatity;
            LastMaintenance = lastMaintenance;
            CrewList = crewList;
            Manufacturer = manufacturer;
        }
    }
}

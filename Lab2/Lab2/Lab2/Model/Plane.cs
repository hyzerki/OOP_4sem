using Lab2.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Model
{
    public enum PlaneType
    {
        Passenger, Cargo, Military
    }

    [PlaneTypeValidate]
    public class Plane
    {
        public Guid Id { get; set; }
        [RegularExpression(@"^[a-zA-ZА-Яа-я0-9 ]+&"), Required]
        public string Model { get; set; }
        public PlaneType Type { get; set; }
        [Range(0, 1000)]
        public int PassengerSeats { get; set; }
        [Range(0, 9999)]
        public int ReleasedAt { get; set; }
        [Range(0, 1000000)]
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

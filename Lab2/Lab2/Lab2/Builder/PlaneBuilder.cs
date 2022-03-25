using Lab1.Model;

namespace Lab2.Builder
{
    public class PlaneBuilder
    {
        private Plane plane;

        public PlaneBuilder()
        {
            plane = new Plane();
        }

        public PlaneBuilder SetModel(string model)
        {
            plane.Model = model;
            return this;
        }

        public PlaneBuilder SetType(PlaneType type)
        {
            plane.Type = type;
            return this;
        }

        public PlaneBuilder SetPassengerSeats(int seats)
        {
            plane.PassengerSeats = seats;
            return this;
        }

        public PlaneBuilder SetCapacity(int capacity)
        {
            plane.Capatity = capacity;
            return this;
        }

        public PlaneBuilder SetReleasedAt(int releasedAt)
        {
            plane.ReleasedAt = releasedAt;
            return this;
        }

        public PlaneBuilder SetLastMaintenance(DateTime date)
        {
            plane.LastMaintenance = date;
            return this;
        }

        public PlaneBuilder AddCrewMate(CrewMate crewMate)
        {
            plane.CrewList.Add(crewMate);
            return this;
        }

        public PlaneBuilder SetManufacturer(Manufacturer? manufacturer)
        {
            plane.Manufacturer = manufacturer!;
            return this;
        }

        public static implicit operator Plane(PlaneBuilder builder)
        {
            return builder.plane;
        }
    }
}

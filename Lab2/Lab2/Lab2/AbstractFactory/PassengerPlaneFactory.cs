using Lab1.Model;

namespace Lab2.AbstractFactory
{
    public class PassengerPlaneFactory : PlaneFactory
    {
        public override PlaneType CreatePlaneType()
        {
            return PlaneType.Passenger;
        }
    }
}

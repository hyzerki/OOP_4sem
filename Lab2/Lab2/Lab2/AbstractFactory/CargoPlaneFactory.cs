using Lab1.Model;

namespace Lab2.AbstractFactory
{
    public class CargoPlaneFactory : PlaneFactory
    {
        public override PlaneType CreatePlaneType()
        {
            return PlaneType.Cargo;
        }
    }
}

using Lab1.Model;

namespace Lab2.AbstractFactory
{
    public class MilitaryPlaneFactory : PlaneFactory
    {
        public override PlaneType CreatePlaneType()
        {
            return PlaneType.Military;
        }
    }
}

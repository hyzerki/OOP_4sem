using Lab1.Model;

namespace Lab2.Adapter
{
    public class ManufacturerToPlaneAdapter : IPlane
    {
        private Manufacturer _manufacturer;
        public ManufacturerToPlaneAdapter(Manufacturer manufacturer)
        {
            _manufacturer = manufacturer;
        }
        public void FLy()
        {
            this._manufacturer.Invade();
        }
    }
}

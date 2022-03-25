using Lab2.Adapter;

namespace Lab1.Model
{
    public class Manufacturer : IInvader
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Founded { get; set; }
        public List<PlaneType> PlaneTypes { get; set; }
        public Manufacturer(Guid id, string name, string country, int founded, List<PlaneType> planeTypes)
        {
            Id = id;
            Name = name;
            Country = country;
            Founded = founded;
            PlaneTypes = planeTypes;
        }

        public Manufacturer()
        {
            Name = "";
            Country = "";
            PlaneTypes = new List<PlaneType>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void Invade()
        {
            MessageBox.Show($"Все самолёты компании {this.Name} вылетели");
        }
    }
}

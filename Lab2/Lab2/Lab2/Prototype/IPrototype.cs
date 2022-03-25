using Newtonsoft.Json;

namespace Lab2.Prototype
{
    internal interface IPrototype<T>
    {
        public virtual T Clone()
        {
            string str = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<T>(str)!;
        }
    }
}

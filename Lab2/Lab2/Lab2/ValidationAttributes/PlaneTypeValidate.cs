using Lab1.Model;
using System.ComponentModel.DataAnnotations;

namespace Lab2.ValidationAttributes
{
    internal class PlaneTypeValidate : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Plane plane)
            {
                if (plane.Manufacturer is not null)
                {
                    if (!plane.Manufacturer.PlaneTypes.Contains(plane.Type))
                    {
                        ErrorMessage = $"Производитель не выпускает самолёты такого типа {plane.Type}.";
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else { return false; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;
using UnitsNet.Units;

namespace RecipeService.UnitConverter
{
    public static class UnitService
    {
        public static double ConvertFromGrams(
            decimal from,
            MeasurementUnit unitTo,
            double density = 1)
        {
            
            var mass = Mass.FromGrams((double)from);
            var volume = Volume.FromCubicMeters(mass.Kilograms/density);

            switch (unitTo)
            {
                case MeasurementUnit.dag:
                    return mass.As(MassUnit.Decagram);
                case MeasurementUnit.kg:
                    return mass.As(MassUnit.Kilogram);
                case MeasurementUnit.ml:
                    return volume.As(VolumeUnit.Milliliter);
                case MeasurementUnit.l:
                    return volume.As(VolumeUnit.Liter);
                case MeasurementUnit.tbsp:
                    return volume.As(VolumeUnit.Tablespoon);
                case MeasurementUnit.tsp:
                    return volume.As(VolumeUnit.Teaspoon);
                default:
                    return mass.As(MassUnit.Gram);
            }
        }
    }
}

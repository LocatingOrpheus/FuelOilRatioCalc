using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelOilRatioCalc
{
    public static class Calculate
    {
        //input of true means calculation will be done with metric volumes.
        public static List<FuelOil> CalculatRatio(bool b, decimal d)
        {
            decimal fifty = d / 50;
            decimal fourty = d / 40;
            decimal thirtytwo = d / 32;
            List<FuelOil> fuelOils = new List<FuelOil>();
            if (b)
            {
                fuelOils.Add(new FuelOil { Ratio = "50:1", Volume = (Math.Round(fifty * 1000, 2)).ToString() + " ml" });
                fuelOils.Add(new FuelOil { Ratio = "40:1", Volume = (Math.Round(fourty * 1000, 2)).ToString() + " ml" });
                fuelOils.Add(new FuelOil { Ratio = "32:1", Volume = (Math.Round(thirtytwo * 1000, 2)).ToString() + " ml" });
            }
            else
            {
                fuelOils.Add(new FuelOil { Ratio = "50:1", Volume = (Math.Round(fifty * 128, 2)).ToString() + " oz" });
                fuelOils.Add(new FuelOil { Ratio = "40:1", Volume = (Math.Round(fourty * 128, 2)).ToString() + " oz" });
                fuelOils.Add(new FuelOil { Ratio = "32:1", Volume = (Math.Round(thirtytwo * 128, 2)).ToString() + " oz" });
            }
            return fuelOils;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Cars
{
    internal class Suv : Car
    {
        public Suv(int maxSpeed, int weight) : base(maxSpeed, weight)
        {

            TypeOfCar = "Suv";
        }
    }
}

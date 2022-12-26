using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh
{
    internal class Vehicle
    {
        public int MaxSpeed { get; set; }

        public int Weight { get; set; }

        public string TypeOfVehicle { get; set; }

        public Vehicle(int maxSpeed, int weight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
        }
    }
}

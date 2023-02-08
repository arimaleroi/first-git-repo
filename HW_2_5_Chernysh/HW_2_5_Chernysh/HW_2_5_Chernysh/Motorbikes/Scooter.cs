using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Motorbikes
{
    internal class Scooter : Motorbike
    {
        public Scooter(int maxSpeed, int weight) : base(maxSpeed, weight)
        {
            TypeOfMotorbike = "Scooter";
        }
    }
}

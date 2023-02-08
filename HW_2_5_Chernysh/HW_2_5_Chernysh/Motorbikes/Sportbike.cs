using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Motorbikes
{
    internal class Sportbike : Motorbike
    {
        public Sportbike(int maxSpeed, int weight) : base(maxSpeed, weight)
        {

            TypeOfMotorbike = "Sport bike";

        }
    }
}

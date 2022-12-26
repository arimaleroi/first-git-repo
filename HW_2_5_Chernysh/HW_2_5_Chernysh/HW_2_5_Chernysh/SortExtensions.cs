using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh
{
    static class SortExtensions
    {

        public static Vehicle[] SortByMaxSpeed(this Vehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                for (int j = 0; j < vehicles.Length - 1; j++)
                {
                    if (vehicles[j].MaxSpeed > vehicles[j + 1].MaxSpeed)
                    {
                        Vehicle v = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = v;
                    }
                }
            }

            return vehicles;
        }
    }
}

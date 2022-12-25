using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Motorbikes
{
    internal class Motorbike : Vehicle
    {
        public Motorbike(int maxSpeed, int weight) : base(maxSpeed, weight)
        {
            TypeOfVehicle = "Motorbike";
        }

        public string TypeOfMotorbike { get; set; }

        public override string ToString()
        {
            return $"{TypeOfMotorbike} | Скорость: {MaxSpeed} км/час | Вес: {Weight} кг";
        }
    }
}

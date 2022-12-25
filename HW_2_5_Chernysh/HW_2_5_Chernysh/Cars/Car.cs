using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Cars
{
    internal class Car : Vehicle
    {
        public Car(int maxSpeed, int weight) : base(maxSpeed, weight)
        {
            TypeOfVehicle = "Car";
        }

        public string TypeOfCar { get; set; }

        public override string ToString()
        {
            return $"{TypeOfCar} | Скорость: {MaxSpeed} км/час | Вес: {Weight} кг";
        }
    }
}

using HW_2_3_Chernysh;
using HW_2_3_Chernysh.Cars;
using HW_2_3_Chernysh.Logger;
using HW_2_3_Chernysh.Motorbikes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh
{
    internal class RentVehicles
    {

        private ILogger consoleLogger;
        private ILogger fileLogger;

        public RentVehicles(ILogger consoleLogger, ILogger fileLogger)
        {
            this.consoleLogger = consoleLogger;
            this.fileLogger = fileLogger;
        }

        public Vehicle[] vehicles =
           {
                new Sedan(150, 1600),
                new SportCar(320, 1300),
                new Suv(220, 2400),
                new Scooter(60, 80),
                new Sportbike(300, 190)
           };

        public void OutputVehicles()
        {
            for (int i = 0; i < vehicles.SortByMaxSpeed().Length; i++)
            {
                Console.WriteLine($"Номер транспорта: {i} | {vehicles[i].ToString()}");
            }
        }

        public void CheckInfo(int numberOfVehicle, int drivingExp)
        {
            try
            {
                if ((vehicles[numberOfVehicle].GetType() == typeof(SportCar) || vehicles[numberOfVehicle].GetType() == typeof(Sportbike)) && drivingExp < 2)
                {
                    consoleLogger.AddLog(new Result(StatusEnum.Error, "Этот транспорт недоступен, Ваш стаж вождения меньше двух лет.", DateTime.Now));
                    fileLogger.AddLog(new Result(StatusEnum.Error, "Этот транспорт недоступен, Ваш стаж вождения меньше двух лет.", DateTime.Now));
                }
                else
                {
                    consoleLogger.AddLog(new Result(StatusEnum.Info, $"Вы успешно арендовали: {vehicles[numberOfVehicle]}", DateTime.Now));
                    fileLogger.AddLog(new Result(StatusEnum.Info, $"Вы успешно арендовали: {vehicles[numberOfVehicle]}", DateTime.Now));
                }
            }
            catch
            {
                consoleLogger.AddLog(new Result(StatusEnum.Error, $"Транспорта с таким номером нет", DateTime.Now));
                fileLogger.AddLog(new Result(StatusEnum.Error, $"Транспорта с таким номером нет", DateTime.Now));
            }
        }
    }
}

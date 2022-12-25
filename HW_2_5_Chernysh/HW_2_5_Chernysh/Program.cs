using HW_2_3_Chernysh.Logger;

namespace HW_2_3_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RentVehicles rentVehicles = new RentVehicles(new ConsoleLogger(), new FileLogger());


            rentVehicles.OutputVehicles();


            Console.WriteLine();


            try
            {
                Console.WriteLine("Сколько лет Вы уже водите транспорт? ");
                int drivingExp = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите номер транспорта, который Вы хотите арендовать: ");
                int numberOfVehicle = int.Parse(Console.ReadLine());

                rentVehicles.CheckInfo(numberOfVehicle, drivingExp);
            }
            catch
            {
                Console.WriteLine("Некорректный ввод, ведите НОМЕР транспорта.");
            }



        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Chernysh
{
    static class Starter
    {
        public static void Run()
        {
            Random random = new Random();

            var logger = Logger.GetInstance();

            for (int i = 0; i < 10; i++)
            {

                switch (random.Next(0, 3))

            {
                case 0:
                    var errorResult = Actions.ErrorAction();
                    logger.AddLog(errorResult);
                    break;

                case 1:
                    var warningResult = Actions.WarningAction();
                    logger.AddLog(warningResult);
                    break;

                case 2:
                    var infoResult = Actions.InfoAction();
                    logger.AddLog(infoResult);
                    break;

                default: throw new Exception("С таким номером нет метода");

            }

            }









        }


    }
}

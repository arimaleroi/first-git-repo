using HW_2_3_Chernysh.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh
{
    public class ConsoleLogger : ILogger
    {
        public void AddLog(Result log)
        {


            Console.WriteLine(Json.JsonLogger(log));
        }
    }
}

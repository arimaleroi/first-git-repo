using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using HW_2_3_Chernysh.Logger;

namespace HW_2_3_Chernysh
{
    internal class FileLogger : ILogger
    {

        public void AddLog(Result log)
        {
            string path = "Logs.json";








            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Json.JsonLogger(log));
            }
        }


    }
}



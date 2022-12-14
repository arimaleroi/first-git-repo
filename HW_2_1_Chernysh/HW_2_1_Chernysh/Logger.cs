using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Chernysh
{
    internal class Logger
    {
        private static Logger _instance;

        public StatusEnum LogLevel { get; set; }

        public List<Result> Logs;

        private Logger()
        {
            Logs = new List<Result>();
        }

        public void AddLog(Result log)
        {
            Logs.Add(log);
        }

        public void Output()
        {
            foreach (var log in Logs)
            {
                if (log.Status == LogLevel)
                {
                    Console.WriteLine($"{log.DateTime}: {log.Status}: {log.Message}");
                }
            }
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }
    }
}

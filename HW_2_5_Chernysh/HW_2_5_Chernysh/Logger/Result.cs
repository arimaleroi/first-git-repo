using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh
{
    public struct Result
    {
        public StatusEnum Status { get; set; }

        public string Message { get; set; }

        public DateTime DateTime { get; set; }

        public Result(StatusEnum status, string message, DateTime dateTime)
        {
            Status = status;
            Message = message;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{DateTime}: {Status}: {Message}";
        }
    }

    public enum StatusEnum
    {
        Error = 0,
        Info = 1
    }

}

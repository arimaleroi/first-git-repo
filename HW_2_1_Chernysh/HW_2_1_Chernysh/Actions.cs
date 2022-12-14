using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Chernysh
{
    public static class Actions
    {
        public static Result InfoAction()
        {
            return new Result(StatusEnum.Info, "Message Info", DateTime.Now);
        }

        public static Result WarningAction()
        {
            return new Result(StatusEnum.Warning, "Message Warning", DateTime.Now);
        }

        public static Result ErrorAction()
        {
            return new Result(StatusEnum.Error, "Message Error", DateTime.Now);
        }
    }

}

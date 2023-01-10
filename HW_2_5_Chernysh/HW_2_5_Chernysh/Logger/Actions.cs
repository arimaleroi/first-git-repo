using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh
{
    public static class Actions
    {
        public static Result InfoAction()
        {
            return new Result(StatusEnum.Info, "Message Info", DateTime.Now);
        }

        public static Result ErrorAction()
        {
            return new Result(StatusEnum.Error, "Message Error", DateTime.Now);
        }
    }

}

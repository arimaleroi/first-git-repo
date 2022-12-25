using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Logger
{
    internal class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}

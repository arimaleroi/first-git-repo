using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_3Chernysh
{
    public class Newspapers
    {
        public string NameOfNewspaper { get; set; }
        public string Headline { get; set; }
        public string Information { get; set; }

        public Newspapers(string nameOfNewspaper, string headline, string information)
        {
            NameOfNewspaper = nameOfNewspaper;
            Headline = headline;
            Information = information;
        }
    }
}

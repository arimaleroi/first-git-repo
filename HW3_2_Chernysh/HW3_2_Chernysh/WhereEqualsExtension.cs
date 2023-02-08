using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_2_Chernysh
{
    public static class Extensions
    {
        public static IEnumerable<T> WhereEquals<T>(this IEnumerable<T> values, T a)
        {
            foreach (var item in values)
            {
                if (a.Equals(item))
                    yield return item;
            }
        }
    }
}

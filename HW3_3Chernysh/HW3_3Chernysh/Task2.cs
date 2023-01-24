using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW3_3Chernysh
{
    internal static class Task2
    {
        public static T FirstOrDefault2<T>(this IEnumerable<T> src, Func<T, bool> func)
        {
            foreach (T element in src)
            {
                if (func(element))
                {
                    return element;
                }
            }
            return default;
        }

        public static IEnumerable<T> SkipWhile2<T>(this IEnumerable<T> src, Func<T, bool> func)
        {
            foreach (T element in src)
            {
                if(func(element) != true)
                {
                    yield return element;
                }
            }
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_2_Chernysh
{
    internal class Item<T>
    {
        private T _data;

        public T Data
        {
            get { return _data; }
            set
            {
                if (value != null)
                    _data = value;
            }
        }

        public Item<T> Next { get; set; }

        public Item(T data)
        {
            Data = data;
        }
    }
}

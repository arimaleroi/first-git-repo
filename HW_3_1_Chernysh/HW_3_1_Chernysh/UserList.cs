using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_1_Chernysh
{
    internal class UserList<T> : IEnumerable, IEnumerator
    {
        public T[] arr = new T[0];

        private int position = -1;

        public void Add(T item)
        {
            if (position < arr.Length)
            {
                position++;
            }

            if (position >= arr.Length)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[position] = item;
                position++;
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            var indexOf = Array.IndexOf(arr, item, 0, arr.Length);
            if (indexOf != -1)
            {
                RemoveAt(indexOf);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index > position)
            {
                return;
            }
            else
            {
                int setStart = index + 1;
                Array.Copy(arr, setStart, arr, index, position - setStart);
                Array.Resize(ref arr, arr.Length - 1);
                position--;
            }
        }

        public void Sort()
        {
            Array.Sort(arr);
        }

        public object Current
        {
            get { return arr[position]; }
        }

        public bool MoveNext()
        {
            if (position < arr.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Node<T> where T: IComparable
    {
        public T Data { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public Node(T data)
        {
            Data = data;
        }

        public bool Add(T data)
        {
            if (data == null)
            {
                return false;
            }

            var compareResult = data.CompareTo(Data);

            if (compareResult < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    return Left.Add(data);
                }
            }
            else if (compareResult == 0)
            {
                return false;
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(data);

                }
                else
                {
                    return Right.Add(data);
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinarySearchTree
{
    internal class Tree<T> : IEnumerable <T>
    {
        private Node<T> root;
        private IComparer<T> comparer;

        public int Count { get; private set; }

        public void Add(T value)
        {
            var node = new Node<T>(value);

            if (root == null)
                root = node;
            else
            {
                Node<T> current = root;
                Node<T> parent = null;

                while (current != null)
                {
                    parent = current;
                    if (comparer.Compare(value, current.Data) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                if (comparer.Compare(value, parent.Data) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            Count++;
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            int height = GetHeight(root);


                foreach (var value in root.Left)
                    yield return value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            int height = GetHeight(root);

            for (int i = 0; i < height; i++)
            {
                foreach (var value in TraverseLevel(root, i))
                    yield return value;
            }
        }
    }
}

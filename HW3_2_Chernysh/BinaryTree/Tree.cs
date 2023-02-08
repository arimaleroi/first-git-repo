using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Tree<T> : IEnumerable where T : IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public bool Add(T data)
        {
            if (data == null)
            {
                return false;
            }

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return true;
            }

            var addResult = Root.Add(data);
            if (addResult)
            {
                Count++;
            }

            return addResult;
        }
        public IEnumerable<T> InOrder()
        {
            if (Root != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = Root;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Data;

                    if (current.Right != null)
                    {
                        current = current.Right;

                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();

                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerable<T> PreOrder()
        {
            if (Root != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = Root;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    Node<T> node = stack.Pop();
                    yield return node.Data;

                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }

                    if (node.Left != null)
                    {
                        stack.Push(node.Left);
                    }
                }
            }
        }
        public IEnumerable<T> PostOrder()
        {
            if (Root == null) yield break;

            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> current = Root;

            while (stack.Count > 0 || Root != null)
            {
                if (Root == null)
                {
                    Root = stack.Pop();
                    if (stack.Count > 0 && Root.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(Root);
                        Root = Root.Right;
                    }
                    else { yield return Root.Data; Root = null; }
                }
                else
                {
                    if (Root.Right != null) stack.Push(Root.Right);
                    stack.Push(Root);
                    Root = Root.Left;
                }
            }
        }

        private int Number { get; set; }

        public IEnumerator<T> GetEnumerator(int number)
        {
            Number = number;
            switch (number)
            {
                case 1:
                    return InOrder().GetEnumerator();
                case 2:
                    return PreOrder().GetEnumerator();
                case 3:
                    return PostOrder().GetEnumerator();
                default:
                    return InOrder().GetEnumerator();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(Number);
        }
    }
}


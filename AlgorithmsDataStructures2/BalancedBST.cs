using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root;

        public int[] BSTArray; // временный массив для ключей дерева

        public BalancedBST()
        {
            Root = null;

        }

        public void CreateFromArray(int[] a)
        {
            // создаём массив дерева BSTArray из заданного
            // ...
            BSTArray = GenerateBBSTArray(a);

            /*
             * if (a.Length > 0)
            {
                BSTArray = new int[a.Length];
                Root.NodeKey = a[0];
                ArrayToTree(a, Root, 1);
            }
             * 
             */
        }

        public void GenerateTree()
        {
            // создаём дерево с нуля из массива BSTArray
            // ...
            if (BSTArray.Length > 0)
            {
                Root = new BSTNode(BSTArray[0], null);
                Root.Level = 1;
                ArrayToTree(0, Root);
            }
        }

        public bool IsBalanced(BSTNode root_node)
        {
            List<int> depths = new List<int>();
            AddLeafsLevel(depths, root_node);
            int[] levels = depths.ToArray();
            Array.Sort(levels);
            return Math.Abs(levels[0] - levels[levels.Length - 1]) < 2;
            // сбалансировано ли дерево с корнем root_node
        }

        public void AddLeafsLevel(List<int> depths, BSTNode node)
        {
            if (node.LeftChild != null) AddLeafsLevel(depths, node.LeftChild);
            if (node.RightChild != null) AddLeafsLevel(depths, node.RightChild);
            if (node.LeftChild == null || node.RightChild == null) depths.Add(node.Level);
        }
        
        private void ArrayToTree(int i, BSTNode node)
        {
            if (node.Parent != null) node.Level = node.Parent.Level + 1;
            i = i * 2 + 1;
            if (i < BSTArray.Length)
            {
                node.LeftChild = new BSTNode(BSTArray[i], node);
                ArrayToTree(i, node.LeftChild);
            }
            i++;
            if (i < BSTArray.Length)
            {
                node.RightChild = new BSTNode(BSTArray[i], node);
                ArrayToTree(i, node.RightChild);
            }
        }

        public static int[] GenerateBBSTArray(int[] a)
        {

            if (a != null)
            {
                a = a.OrderBy(i => i).ToArray();
                int depth = -1;
                for (int size = a.Length; size != 0; depth++)
                    size >>= 1;

                int[] b = new int[(2 << (depth)) - 1];
                if (a.Length == b.Length)
                {
                    GetArray(b, a, 0);
                    return b;
                }
            }
            return null;
        }

        public static void GetArray(int[] b, int[] a, int nx)
        {
            b[nx] = a[a.Length / 2];
            if (a.Length == 1) return;
            int[] c = new int[a.Length / 2];

            Array.Copy(a, 0, c, 0, a.Length / 2);
            GetArray(b, c, nx * 2 + 1);

            Array.Copy(a, a.Length / 2 + 1, c, 0, a.Length / 2);
            GetArray(b, c, nx * 2 + 2);
        }

    }
}
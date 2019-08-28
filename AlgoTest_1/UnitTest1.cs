using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {
        //              11
        //          0       23
        //      -3    5   16    91
        //
        [TestMethod]
        public void TestMethod1()
        {
            BalancedBST bbst = new BalancedBST();
            int[] ar = new int[] { 16, 23, 91, 0, -3, 5, 11 };
            bbst.CreateFromArray(ar);
            bbst.GenerateTree();
            bool b = bbst.IsBalanced(bbst.Root);

            BSTNode node_1 = bbst.Root.LeftChild.LeftChild;
            node_1.LeftChild = new BSTNode(-5, node_1);
            node_1.LeftChild.Level = 4;

            BSTNode node_2 = bbst.Root.RightChild.RightChild;
            node_2.LeftChild = new BSTNode(56, node_2);
            node_2.RightChild = new BSTNode(100, node_2);
            node_2.LeftChild.Level = 4;
            node_2.RightChild.Level = 4;

            node_2.LeftChild.RightChild = new BSTNode(66, node_2.LeftChild);
            node_2.LeftChild.RightChild.Level = 5;

            b = bbst.IsBalanced(bbst.Root);
        }
    }
}

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
            bbst.GenerateTree(ar);

            Assert.AreEqual(true, bbst.IsBalanced(bbst.Root));

            /*
             *      -3
             *    -5   
             */
            BSTNode node_1 = bbst.Root.LeftChild.LeftChild;
            node_1.LeftChild = new BSTNode(-5, node_1);
            node_1.LeftChild.Level = node_1.Level + 1;

            Assert.AreEqual(true, bbst.IsBalanced(node_1.Parent));


            /*          0    23
             *       -3  5     91
             *     -5        56   100
             *                66
             */
            BSTNode node_2 = bbst.Root.RightChild.RightChild;
            node_2.LeftChild = new BSTNode(56, node_2);
            node_2.RightChild = new BSTNode(100, node_2);
            node_2.LeftChild.Level = node_2.Level + 1;
            node_2.RightChild.Level = node_2.Level + 1;
            node_2.LeftChild.RightChild = new BSTNode(66, node_2.LeftChild);
            node_2.LeftChild.RightChild.Level = node_2.Level + 2;

            Assert.AreEqual(false, bbst.IsBalanced(bbst.Root));

            /*          0         23
             *      -3    5     16    91
             *   -5 -1  3  7   8  18 56   100
             *                        66
             */
            node_1.RightChild = new BSTNode(-1, node_1);
            node_1.RightChild.Level = node_1.Level + 1;
            BSTNode node_3 = node_1.Parent.RightChild;
            node_3.LeftChild = new BSTNode(3, node_3);
            node_3.RightChild = new BSTNode(7, node_3);
            node_3.RightChild.Level = node_3.Level + 1;
            node_3.LeftChild.Level = node_3.Level + 1;

            BSTNode node_4 = bbst.Root.RightChild.LeftChild;
            node_4.RightChild = new BSTNode(18, node_4);
            node_4.LeftChild = new BSTNode(8, node_4);
            node_4.LeftChild.Level = node_4.Level + 1;
            node_4.RightChild.Level = node_4.Level + 1;

            Assert.AreEqual(true, bbst.IsBalanced(bbst.Root));
        }
    }
}

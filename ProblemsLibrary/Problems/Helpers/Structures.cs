using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemsLibrary.Problems.Helpers
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode() { }

        public TreeNode(int val=0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left; 
            this.right = right;
        }       
    }

    public class Height
    {
        public int Value { get; set; }
        public Height()
        {
            this.Value = 0;
        }
    }

    public class CustomNode
    {
        public CustomNode left, right;

        public CustomNode(CustomNode right, CustomNode left, int val)
        {
            this.right = right;
            this.left = left;
            this.value = val;
        }

        /// the value of this​​​​​​​‌‌‌‌‌‌​‌‌​‌‌‌​‌​‌​‌‌​‌​‌ node
        public int value;

        public CustomNode Find(int v)
        {
            if (this.value == v) return this;
            else if (left != null && left.value < v) return left.Find(v);
            else if (right != null && right.value >= v) return right.Find(v);
            else return null;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = int.MinValue, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override bool Equals(object obj)
        {   
            var listNode = (ListNode)obj;
            var curr = this;
            while (curr != null && listNode != null)
            {
                if (curr.val == listNode.val)
                {
                    curr = curr.next;
                    listNode = listNode.next;
                }
            }

            if (curr != null || listNode != null) return false;

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -903652156;
            hashCode = hashCode * -1521134295 + val.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ListNode>.Default.GetHashCode(next);
            return hashCode;
        }
    }
}

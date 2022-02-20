using ProblemsLibrary.Problems.Helpers;
using System.Collections.Generic;

namespace ProblemsLibrary.Problems
{
    public static class ListProblems
    {
        public static ListNode DeleteDuplicates(this ListNode head)
        {
            if (head.next == null) return head;

            var prevValue = head.val;
            var list = new List<int> { prevValue };
            for (var cur = head.next; cur != null; cur = cur.next)
            {
                if (cur.val == prevValue) continue;
                list.Add(cur.val);
                prevValue = cur.val;
            }

            var res = new ListNode(list[list.Count - 1]);
            for (var i = list.Count - 2; i >= 0; i--)
            {
                res = new ListNode(list[i], res);
            }

            return res;
        }
    }
}

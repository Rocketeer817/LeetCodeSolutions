/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        ListNode dummy = new ListNode();

        ListNode tail = dummy;
        ListNode curr = head;

        while(curr!=null && curr.next!=null){
            ListNode adj = curr.next;
            ListNode next = curr.next.next;

            tail.next= adj;
            adj.next = curr;

            curr.next = null;
            tail = curr;

            curr = next;

        }

        tail.next = curr;

        return dummy.next;
    }
}
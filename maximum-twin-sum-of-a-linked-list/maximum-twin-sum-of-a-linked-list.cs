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
    public int PairSum(ListNode head) {
        // steps: 
        //1. find the middle node( node n/2 ) and tail node (node n-1)
        //2. disconnect the node n/2-1 and node n/2 .
        //3. Reverse the linked list with middle node as head
        //4. Finally traverse both linked lists at same pace to find the twin nodes and twin sum
        //5. find max of twin sums

        //node n/2-1
        ListNode middleNode = FindMiddleNode(head);
        //node n/2
        ListNode head2 = middleNode.next;

        middleNode.next = null;

        ListNode tempHead = ReverseLL(head2);

        int twinSum = 0;

        ListNode curr1 = head;
        ListNode curr2 = tempHead;

        while(curr1!=null && curr2!=null){
            twinSum = Math.Max(twinSum,curr1.val+curr2.val);
            curr1 = curr1.next;
            curr2 = curr2.next;
        }

        return twinSum;

    }

    

    public ListNode ReverseLL(ListNode head){
        // tail  curr->next-> ... => tail<-curr next->...
        ListNode curr = head;

        ListNode tail = null;

        while(curr!=null){
            ListNode next = curr.next;

            curr.next = tail;
            tail = curr;
            curr = next;
        }

        return tail;

    }

    public ListNode FindMiddleNode(ListNode head){
        ListNode curr1 = head;
        ListNode curr2 = head.next;

        while(curr2.next!=null){
            curr1 = curr1.next;
            curr2 = curr2.next.next;
        }

        return curr1;

    }


}
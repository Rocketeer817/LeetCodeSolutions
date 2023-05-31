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
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode curr = head;

        

        ListNode dummy = new ListNode();
        ListNode tail = dummy;

        while(curr!=null){
            ListNode currHead = curr;
            int count = 0;
            ListNode prev = null;
            while(count<k && curr!=null){
                prev = curr;
                curr = curr.next;
                count++;
            }

            prev.next = null;
            if(count<k){
                tail.next = currHead;
            }
            else{
                tail.next = Reverse(currHead);
                tail = currHead;
            }
            
            count = 0;           
            
        }

        return dummy.next;
        
    }

    public ListNode Reverse(ListNode head){
        ListNode curr = head;

        ListNode prev = null;

        while(curr!=null){
            
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
            
        }

        Console.WriteLine(prev.val);

        return prev;
    }
}
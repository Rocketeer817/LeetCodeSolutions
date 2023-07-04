/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        return mergeSortLike(lists,0,lists.length-1);
    }

    public ListNode mergeSortLike(ListNode[] lists, int l, int r){
        if(l==r){
            return lists[l];
        }
        if(l>r){
            return null;
        }
        int mid = (l+r)/2;

        ListNode h1 = mergeSortLike(lists,l,mid);
        ListNode h2 = mergeSortLike(lists,mid+1,r);

        return merge2Lists(h1,h2);
    }

    public ListNode merge2Lists(ListNode h1, ListNode h2){
        ListNode dummy = new ListNode();

        ListNode curr = dummy;
        ListNode ptr1 = h1;
        ListNode ptr2 = h2;

        while(ptr1!=null && ptr2!=null){
            if(ptr1.val<=ptr2.val){
                ListNode temp = ptr1;
                ptr1 = ptr1.next;
                temp.next = null;
                curr.next = temp;
                curr = curr.next;
            }
            else{
                ListNode temp = ptr2;
                ptr2 = ptr2.next;
                temp.next = null;
                curr.next = temp;
                curr = curr.next;
            }
        }

        if(ptr1!=null){
            curr.next = ptr1;
        }

        if(ptr2!=null){
            curr.next = ptr2;
        }

        return dummy.next;

    }
}
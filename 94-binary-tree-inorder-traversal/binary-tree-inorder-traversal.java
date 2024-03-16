/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {

    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> ans = new ArrayList<>();

        LinkedList<TreeNode> stack = new LinkedList<>();

        TreeNode ptr = root;

        while(ptr!=null || stack.size()>0){
            if(ptr==null){
                ptr = stack.pollLast();
                ans.add(ptr.val);

                ptr = ptr.right;
            }
            else{
                stack.addLast(ptr);
                ptr = ptr.left;
            }            
        }

        return ans;
    }

    
}
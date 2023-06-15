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
    TreeNode prev;
    int minDifference = Integer.MAX_VALUE;

    public int getMinimumDifference(TreeNode root) {
        //Abs(node - node.left) , Abs(node - node.right)

        inOrder(root);

        return minDifference;
    }

    public void inOrder(TreeNode root,List<Integer> list){
        if(root==null){
            return;
        }

        inOrder(root.left,list);

        list.add(root.val);

        inOrder(root.right,list);
        
    }

    public void inOrder(TreeNode root){
        if(root==null){
            return;
        }

        inOrder(root.left);

        if(prev!=null){
            minDifference = Math.min(minDifference,root.val-prev.val);
        }

        prev = root;

        inOrder(root.right);
        
    }
}
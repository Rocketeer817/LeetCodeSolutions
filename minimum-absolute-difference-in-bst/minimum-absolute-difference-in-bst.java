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
    
    public int getMinimumDifference(TreeNode root) {
        //Abs(node - node.left) , Abs(node - node.right)
        List<Integer> list = new ArrayList<>();

        inOrder(root,list);

        int ans = Integer.MAX_VALUE;

        for(int i=1;i<list.size();i++){
            ans = Math.min(list.get(i)-list.get(i-1),ans);
        }

        return ans;
    }

    public void inOrder(TreeNode root,List<Integer> list){
        if(root==null){
            return;
        }

        inOrder(root.left,list);

        list.add(root.val);

        inOrder(root.right,list);
        
    }
}
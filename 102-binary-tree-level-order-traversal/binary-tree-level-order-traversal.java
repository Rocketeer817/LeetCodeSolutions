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
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> ans = new ArrayList<>();

        if(root==null){
            return ans;
        }

        Queue<TreeNode> q = new LinkedList<>();

        q.add(root);

        while(q.size()>0){
            int lvlCount = q.size();
            List<Integer> currLvl = new ArrayList<>();
            while(lvlCount>0){
                TreeNode currNode = q.poll();
                currLvl.add(currNode.val);
                lvlCount--;

                if(currNode.left != null){
                    q.add(currNode.left);
                }

                if(currNode.right != null){
                    q.add(currNode.right);
                }
            }
            ans.add(currLvl);
        }

        return ans;
    }
}
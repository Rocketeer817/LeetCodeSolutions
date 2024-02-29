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
    public boolean isEvenOddTree(TreeNode root) {
        Queue<TreeNode> q = new LinkedList<>();

        q.add(root);

        int lvl = 0;

        while(q.size()>0){
            //level order traversing
            int cnt = q.size();
            //check if the elements of this level are following the order
            int val = (lvl%2==0)?0:1000001;

            while(cnt>0){
                TreeNode node = q.poll();
                //process this node for the Even-Odd conditions
                if(lvl%2==0){
                    if(node.val%2==1 && node.val>val){
                        val = node.val;
                    }
                    else{
                        return false;
                    }
                }
                else{
                    if(node.val%2==0 && node.val<val){
                        val = node.val;
                    }
                    else{
                        return false;
                    }
                }

                //Add the children of node to the queue to process next level
                if(node.left!=null){
                    q.add(node.left);
                }

                if(node.right!=null){
                    q.add(node.right);
                }
                cnt--;
            }

            lvl++;
        }

        return true;
    }
}
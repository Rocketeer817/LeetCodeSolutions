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
    public int maxLevelSum(TreeNode root) {
        Queue<Info> q = new LinkedList<>();

        q.offer(new Info(root,1));


        int maxLvl = 1; long maxSum = Long.MIN_VALUE;

        int ptr = 1;
        while(!q.isEmpty()){

            int currSize = q.size();

            long sum = 0;

            while(currSize-->0){
                Info curr = q.poll();
                sum += curr.Node.val;

                if(curr.Node.left!=null){                   
                    q.offer(new Info(curr.Node.left,curr.Level+1));
                }

                if(curr.Node.right!=null){
                    q.offer(new Info(curr.Node.right,curr.Level+1));
                }
            }

            if(sum>maxSum){
                maxLvl = ptr;
                maxSum = sum;
            }

            ptr++;
            
        }

        return maxLvl;

    }


}

class Info{
    public TreeNode Node;
    public int Level;

    public Info(TreeNode node, int level){
        this.Node = node;
        this.Level = level;
    }
}
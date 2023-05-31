/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BalanceBST(TreeNode root) {
        List<int> inList = new List<int>();
        InOrder(root,inList);

        return BuildBBST(inList,0,inList.Count-1);
    }

    public void InOrder(TreeNode node, List<int> inOrderList){
        if(node == null){
            return;
        }

        InOrder(node.left,inOrderList);

        inOrderList.Add(node.val);

        InOrder(node.right,inOrderList);
    }

    public TreeNode BuildBBST( List<int> inList, int l , int h){
        if(l>h){
            return null;
        }

        int mid = l + (h-l)/2;

        TreeNode root = new TreeNode(inList[mid]);

        root.left = BuildBBST(inList,l, mid-1);

        root.right = BuildBBST(inList,mid+1,h);

        return root;
    }
}
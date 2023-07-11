/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    private int targetHeight = 0;
    public List<Integer> distanceK(TreeNode root, TreeNode target, int k) {
        List<Info> ancestors = new ArrayList<Info>();
        FindAncestors(root,target,ancestors,0);

        List<Integer> ans = new ArrayList<>();

        //For target node find the nodes
        FindNodes(target,ans,k);

        for(Info ancestor : ancestors){
            int distance = targetHeight - ancestor.height;
            
            int reqDistance = k-distance;

            //System.out.println(ancestor.node.val + " , "+reqDistance);

            if(reqDistance==0){
                ans.add(ancestor.node.val);
            }

            if(ancestor.direction == 0){
                FindNodes(ancestor.node.right,ans,reqDistance-1);
            }
            else{
                FindNodes(ancestor.node.left,ans,reqDistance-1);
            }

        }

        return ans;
    }

    public boolean FindAncestors(TreeNode root, TreeNode target, List<Info> list, int h){
        if(root==null){
            return false;
        }
        else if(root==target){
            targetHeight = h;
            return true;
        }

        if(FindAncestors(root.left,target,list,h+1)){
            //System.out.println(root.val + " , "+h);
            list.add(new Info(root,h,0));
        }
        else if(FindAncestors(root.right,target,list,h+1)){
            //System.out.println(root.val + " , "+h);
            list.add(new Info(root,h,1));
        }
        else{
            return false;
        }

        return true;

    }

    public void FindNodes(TreeNode root, List<Integer> list, int dist){
        if(root==null || dist<0){
            return;
        }

        if(dist==0){
            //System.out.println(root.val);
            list.add(root.val);
            return;
        }

        FindNodes(root.left,list,dist-1);
        FindNodes(root.right,list,dist-1);
    }
}

class Info{
    TreeNode node;
    //height from root
    int height;
    //direction is 0 for left, 1 for right
    int direction;

    public Info(TreeNode r,int h, int d){
        this.node = r;
        this.height = h;
        this.direction = d;
    }
}
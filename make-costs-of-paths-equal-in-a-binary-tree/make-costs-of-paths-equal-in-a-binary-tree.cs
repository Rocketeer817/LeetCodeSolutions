public class Solution {
    int ans = 0;
    public int MinIncrements(int n, int[] cost) {
        dfs(1,cost);
        return ans;
    }

    public int dfs(int node, int[] cost){
        if(node>cost.Length){
            return 0;
        }

        int t1 = dfs(2*node,cost);
        int t2 = dfs(2*node+1, cost);

        ans += Math.Abs(t1-t2);

        return cost[node-1] + Math.Max(t1,t2);
    }
}
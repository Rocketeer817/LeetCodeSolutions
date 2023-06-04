public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        int n = isConnected.Length;
        bool[] vis = new bool[n];

        Array.Fill(vis,false);

        int ans = 0;
        for(int i=1;i<=n;i++){
            if(vis[i-1]==false){
                dfs(isConnected,vis,i);
                ans++;
            }
        }

        return ans;
    }

    public void dfs(int[][] graph, bool[] vis,int curr){
        vis[curr-1] = true;

        for(int i=1;i<=graph[curr-1].Length;i++){
            if(graph[curr-1][i-1]==1 && vis[i-1]==false){
                dfs(graph,vis,i);
            }
        }
    }
}
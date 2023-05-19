public class Solution {
    public bool IsBipartite(int[][] graph) {
        int n = graph.Length;

        int[] nodes = new int[n];

        Array.Fill(nodes,-1);

        bool ans = true;

        for(int i=0;i<n;i++){
            if(nodes[i]==-1){
                ans = ans && Dfs(graph,i,nodes,0);
            }
        }

        return ans;
    }

    public bool Dfs(int[][] graph,int u,int[] nodes,int col){
        col = col%2;
        if(nodes[u]!=-1 && nodes[u]!=col){
            return false;
        }
        else if(nodes[u]==col){
            return true;
        }
        nodes[u] = col;

        bool ans = true;

        for(int i=0;i<graph[u].Length;i++){
            int v = graph[u][i];
            ans = ans && Dfs(graph,v,nodes,col+1);
        }

        return ans;
    }
}
public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        
        int[] indegree = new int[n];

        Array.Fill(indegree,-1);

        for(int i=0;i<edges.Count;i++){
            indegree[edges[i][1]] = edges[i][0];
        }

        IList<int> ans = new List<int>();

        for(int i=0;i<n;i++){
            if(indegree[i]==-1){
                ans.Add(i);
            }
        }

        return ans;

    }
}
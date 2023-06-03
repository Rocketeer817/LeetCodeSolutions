public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        List<int>[] graph = new List<int>[n];

        for(int i=0;i<n;i++){
            graph[i] = new List<int>();
        }

        for(int i=0;i<manager.Length;i++){
            if(i==headID){
                continue;
            }
            graph[manager[i]].Add(i);
        }

        return TimeTaken(graph,headID,informTime);
    }

    public int TimeTaken(List<int>[] graph,int curr, int[] informTime){
        int time = 0;
        
        int t = informTime[curr];
        for(int i=0;i<graph[curr].Count;i++){
            time = Math.Max(t + TimeTaken(graph,graph[curr][i],informTime) , time );
        }

        Console.WriteLine($"{curr} -> {time}");

        return time;
    }
}
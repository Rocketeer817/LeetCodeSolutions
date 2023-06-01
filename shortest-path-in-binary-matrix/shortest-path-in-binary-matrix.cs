public class Solution {
    private List<List<int>> moves;
    public int ShortestPathBinaryMatrix(int[][] grid) {
        moves = new List<List<int>>();

        moves.Add(new List<int>{0,1});
        moves.Add(new List<int>{0,-1});
        moves.Add(new List<int>{1,0});
        moves.Add(new List<int>{-1,0});
        moves.Add(new List<int>{1,1});
        moves.Add(new List<int>{1,-1});
        moves.Add(new List<int>{-1,1});
        moves.Add(new List<int>{-1,-1});

        return Bfs(grid);
        
    }

    public int Bfs(int[][] grid){
        int n = grid.Length;
        if(grid[0][0]!=0){
            return -1;
        }
        Queue<int[]> q = new Queue<int[]>();
        bool[][] vis = new bool[n][];
        for(int i=0;i<n;i++){
            vis[i] = new bool[n];
            Array.Fill(vis[i],false);
        }

        q.Enqueue(new int[]{0,0,1});

        vis[0][0] = true;

        if(n==1 ){
            return 1;
        }

        while(q.Count>0){
            int[] temp = q.Dequeue();
            int x = temp[0], y = temp[1], d = temp[2];

            foreach(List<int> move in moves){
                int nx = x + move[0];
                int ny = y + move[1];

                int nd = d+1;

                if(Check(grid,nx,ny,vis)){
                    q.Enqueue(new int[]{nx,ny,d+1});
                    vis[nx][ny] = true;

                    if(nx==n-1 && ny==n-1){
                        return d+1;
                    }
                }

                
            }
        }

        return -1;


    }

    public bool Check(int[][] grid, int x, int y,bool[][] vis){
        int n = grid.Length;

        if(x>=0 && x<n && y>=0 && y<n && vis[x][y]==false && grid[x][y]==0){
            return true;
        }

        return false;
    }
}
public class Solution {
    int[][] moves ;
    public int ShortestBridge(int[][] grid) {
        //Breadth first search
        int n = grid.Length;

        moves = new int[4][];

        moves[0] = new int[2];
        moves[0][0] = 1; moves[0][1] = 0;

        moves[1] = new int[2];
        moves[1][0] = -1; moves[1][1] = 0;

        moves[2] = new int[2];
        moves[2][0] = 0; moves[2][1] = 1;

        moves[3] = new int[2];
        moves[3][0] = 0; moves[3][1] = -1;

        Queue<int[]> q = new Queue<int[]>();

        int[][] vis = new int[n][];
        for(int i=0;i<n;i++){
            vis[i] = new int[n];
            Array.Fill(vis[i],0);
        }

        int fx =-1,fy=-1;
        for(int i=0;i<n;i++){
            for(int j=0;j<n;j++){
                if(grid[i][j]==1){
                    fx = i;
                    fy = j;
                    break;
                }
            }
            if(fx>=0){
                break;
            }
        }

        //Console.WriteLine($"start from : {fx},{fy}");

        DFS(grid,fx,fy,n,vis);

        //Console.WriteLine($"finished for : {fx},{fy}");

        for(int i=0;i<n;i++){
            for(int j=0;j<n;j++){
                if(vis[i][j]==1){
                    q.Enqueue(new int[]{i,j,0});
                }
            }
        }

        while(q.Count>0){
            int[] temp = q.Dequeue();
            int x = temp[0],y = temp[1],d = temp[2];

            for(int i=0;i<4;i++){
                int nx = x+moves[i][0];
                int ny = y+moves[i][1];


                if(nx>=0 && nx<n && ny>=0 && ny<n && vis[nx][ny]==0)            {
                    if(grid[nx][ny]==1){
                        return d;
                    }
                    else{
                        q.Enqueue(new int[]{nx,ny,d+1});
                        vis[nx][ny] = 1;
                    }
                }
                
            }
        }

        return -1;

    }

    public void DFS(int[][] grid,int i,int j,int n,int[][] vis){
        
        vis[i][j] = 1;
        
        for(int x=0;x<4;x++){
            int ni = i+moves[x][0];
            int nj = j+moves[x][1];

            if(ni>=0 && ni<n && nj>=0 && nj<n && vis[ni][nj]==0 && grid[ni][nj]==1){
                //Console.WriteLine($"{ni},{nj}");
                DFS(grid,ni,nj,n,vis);
            }
        }

        //Console.WriteLine($"Explored {i},{j}");
    }
}
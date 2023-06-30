class Solution {
    int[][] moves;
    public int latestDayToCross(int row, int col, int[][] cells) {
        moves = new int[][]{{0,1},{0,-1},{1,0},{-1,0}};

        int l = 0 ;
        int h = cells.length-1;

        int ans = 0;

        while(l<=h){
            int mid = (l+h)/2;

            if(check(row,col,cells,mid)){
                ans = mid+1;
                l = mid+1;
            }
            else{
                h = mid-1;
            }
        }

        return ans;
    }

    public boolean check( int row, int col, int[][] cells, int idx){
        int[][] grid = new int[row][col];

        for(int i=0;i<row;i++){
            Arrays.fill(grid[i],0);
        }

        for(int i=0;i<=idx;i++){
            int r = cells[i][0]-1 , c = cells[i][1]-1;
            grid[r][c] = 1;
        }

        return bfs(grid, row , col);
    }

    public boolean bfs(int[][] grid, int r, int c){
        Queue<int[]> q = new LinkedList<>();

        boolean[][] vis = new boolean[r][c];

        for(int i=0;i<r;i++){
            Arrays.fill(vis[i],false);
        }

        //row 0 
        for(int j = 0;j<c;j++){
            if(grid[0][j]==1){
                continue;
            }

            q.offer(new int[]{0,j,0});
            vis[0][j] = true;
        }

        while(q.isEmpty() == false){
            int[] temp = q.poll();

            int x = temp[0], y= temp[1], d = temp[2];

            for(int[] move : moves){
                int nx = x+move[0], ny = y+move[1];
                if(nx>=0 && nx<r && ny>=0 && ny<c && vis[nx][ny]==false && grid[nx][ny]==0){
                    if(nx==r-1){
                        return true;
                    }

                    q.offer(new int[]{nx,ny,d+1});
                    vis[nx][ny] = true;
                }
            }
        }

        return false;        
    }
}
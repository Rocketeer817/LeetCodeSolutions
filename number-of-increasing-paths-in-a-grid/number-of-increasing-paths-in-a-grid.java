class Solution {
    int[][] moves;
    long[][] dp;
    long mod;
    public int countPaths(int[][] grid) {

        moves = new int[4][2];

        moves[0][0] = 0; moves[0][1] = 1;
        moves[1][0] = 1; moves[1][1] = 0;
        moves[2][0] = 0; moves[2][1] = -1;
        moves[3][0] = -1; moves[3][1] = 0;

        mod = (long)Math.pow(10,9)+7;

        dp = new long[grid.length][grid[0].length];

        for(int i=0;i<grid.length;i++){
            for(int j=0;j<grid[0].length;j++){
                dp[i][j] = -1;
            }
        }

        long ans = 0;
        for(int i=0;i<grid.length;i++){
            for(int j=0;j<grid[0].length;j++){
                long k = dfs(grid,i,j);
                //System.out.println(i+","+j+":::"+k);
                ans += k;
                ans = ans%mod;
            }
        }

        return (int)ans;
    }

    public long dfs(int[][] grid, int x, int y){
        if(check(grid,x,y)==false){
            return 0;
        }

        if(dp[x][y] != -1){
            return dp[x][y];
        }

        long ans = 1;

        for(int i=0;i<4;i++){
            int nx = x+moves[i][0], ny = y+moves[i][1];
            //System.out.println(nx+","+ny+":::"+ check(grid,nx,ny)+"->"+x+","+y);
            if(check(grid,nx,ny) && grid[nx][ny]>grid[x][y]){
                ans += dfs(grid,nx,ny);
                ans = ans%mod;
                //System.out.println(nx+","+ny+":::"+ans);
                
            }

        }

        dp[x][y] = ans;

        return ans;
    }

    public boolean check(int[][] grid, int x , int y){
        if(x<0 || y<0 || x>=grid.length || y>=grid[0].length){
            return false;
        }

        return true;
    }
}
class Solution {
    public int countNegatives(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;

        int ans = 0;

        int x = 0, y = n-1;

        while(x>=0 && x<m && y>=0 && y<n){
            if(grid[x][y]<0){
                ans += m-x;
                y--;
            }
            else{
                x++;
            }
        }

        return ans;
    }
}
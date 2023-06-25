class Solution {
    private long[][] dp;
    private long mod;
    public int countRoutes(int[] locations, int start, int finish, int fuel) {
        int n = locations.length;

        int[][] graph = new int[n][n];

        for(int i=0;i<n;i++){
            for(int j=0;j<n;j++){
                graph[i][j] = Math.abs(locations[i]-locations[j]);
            }
        }

        long ans = 0;
        mod = (long)Math.pow(10,9) + 7;

        dp = new long[n][fuel+1];

        for(int i=0;i<n;i++){
            Arrays.fill(dp[i],-1);
        }

        

        ans = bottomUp(locations,start,finish,fuel);

        return (int)ans;


    }

    public long bottomUp(int[] locations, int start, int finish, int rf){
        if(rf<0){
            return 0;
        }

        if(dp[start][rf]!=-1){
            return dp[start][rf];
        }

        long ans = 0;
        if(start==finish){
            ans++;
        }

        for(int i=0;i<locations.length;i++){
            if(start!=i){
                ans = ans + bottomUp(locations,i,finish,rf-Math.abs(locations[i]-locations[start]));
                ans = ans%mod;
            }
        }

        dp[start][rf] = ans;
        
        return ans;
    }
}

class Node{
    public int index;

    public Node(int idx){
        this.index = idx;
    }
}
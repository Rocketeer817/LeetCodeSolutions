public class Solution {
    int[,,] dp ;
    public int StoneGameII(int[] piles) {
        int n = piles.Length;
        dp = new int[2,n,n+1];

       

        for(int i=0;i<n;i++){
            for(int j=0;j<=n;j++){
                dp[0,i,j] = -1;
                dp[1,i,j] = -1;
            }
        }




        return f(piles,n,0,0,1);
    }


    //f represents the max no of stones Alice can get at this stage
    public int f(int[] piles, int n, int p, int idx, int cnt){
        if(idx>=n){
            return 0;
        }

        if(dp[p,idx,cnt]!=-1){
            return dp[p,idx,cnt];
        }

        int k = Math.Min(n-idx,2*cnt);

        int s = 0;
        int ans = (p==0)?int.MinValue:int.MaxValue;


        for(int j=0;j<k;j++){
            int currIdx = idx+j;
            s += piles[currIdx];
            //curr person is Alice
            if(p==0){
                ans = Math.Max(ans, s + f(piles,n,1,currIdx+1,Math.Max(cnt,j+1)));
            }
            //curr person is Bob  and the return is the max Alice can get. But since it is optimised Bob only allows Alice to get minimum possible.
            else{
                ans = Math.Min(ans, f(piles,n,0,currIdx+1,Math.Max(cnt,j+1)));
            }
        }


        dp[p,idx,cnt] = ans;

        return ans;
    }
}
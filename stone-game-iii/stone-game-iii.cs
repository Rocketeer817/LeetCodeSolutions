public class Solution {
    public int[,] dp;
    public string StoneGameIII(int[] stoneValue) {
        int n = stoneValue.Length;

        dp = new int[2,n];

        for(int i=0;i<n;i++){
            dp[0,i] = -1;
            dp[1,i] = -1;
        }

        int a = f(stoneValue,n,0,0);

        int sum = 0;
        for(int i=0;i<n;i++){
            sum += stoneValue[i];
        }

        int b = sum-a;

        if(a==b){
            return "Tie";
        }

        return a>b?"Alice":"Bob";
    }

    //f represents the max no of stones Alice can get at this stage
    public int f(int[] piles, int n, int p, int idx){
        if(idx>=n){
            return 0;
        }

        if(dp[p,idx]!=-1){
            return dp[p,idx];
        }

        int s = 0;
        int ans = (p==0)?int.MinValue:int.MaxValue;

        int k = Math.Min(n-idx,3);

        for(int j=0;j<k;j++){
            int currIdx = idx+j;
            //Console.WriteLine(currIdx<n);
            s += piles[currIdx];
            //curr person is Alice
            if(p==0){
                ans = Math.Max(ans, s + f(piles,n,1,currIdx+1));
            }
            //curr person is Bob  and the return is the max Alice can get. But since it is optimised Bob only allows Alice to get minimum possible.
            else{
                ans = Math.Min(ans, f(piles,n,0,currIdx+1));
            }
        }


        dp[p,idx] = ans;

        return ans;
    }
}
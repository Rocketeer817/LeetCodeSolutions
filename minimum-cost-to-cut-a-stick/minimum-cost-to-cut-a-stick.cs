public class Solution {
    public int[][] dp;
    public int MinCost(int n, int[] cuts) {
        int m = cuts.Length;
        //Console.WriteLine($" {m}");
        dp = new int[m+2][];

        for(int i=0;i<m+2;i++){
            dp[i] = new int[m+2];
            Array.Fill(dp[i],-1);
        }

        //Console.WriteLine($" {cuts.Length}");

        List<int> cutsNew = new List<int>();

        cutsNew.Add(0);

        for(int i=0;i<cuts.Length;i++){
            cutsNew.Add(cuts[i]);
        }

        cutsNew.Add(n);

        cutsNew.Sort();

        //Console.WriteLine($" {cutsNew.Count}");

        return cost(n,cutsNew,0,m+1);
    }

    public int cost(int n,List<int> cutsNew,int l, int r){

        if(l>=r){
            return 0;
        }    

        if(dp[l][r]!=-1){
            return dp[l][r];
        }
        //Console.WriteLine($"Get details of {l},{r}");

        if(r-l == 1){
            dp[l][r] = 0;
            return dp[l][r];
        }

        int ans = int.MaxValue;

        for(int i=l+1;i<r;i++){           
            //Console.WriteLine(i);
            int temp = cutsNew[r]-cutsNew[l] + cost(n,cutsNew,l,i) + cost(n,cutsNew,i,r);
            ans = Math.Min(temp,ans);            
        }

        dp[l][r] = ans;

        //Console.WriteLine($"{l},{r} --> {ans}");

        return dp[l][r];
    }
}
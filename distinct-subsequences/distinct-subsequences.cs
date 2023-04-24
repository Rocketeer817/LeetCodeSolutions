public class Solution {
    public int NumDistinct(string s, string t) {
        int n = s.Length;
        int m = t.Length;

        int[,] dp = new int[n,m];

        //so col is m and row is n
        dp[0,0] = (s[0]==t[0])?1:0;

        for(int r=1;r<n;r++){
            int x1 = (s[r]==t[0])?1:0;
            int x2 = dp[r-1,0];
            dp[r,0] = x1+x2;
        }

        for(int c=1;c<m;c++){
            dp[0,c] = 0;
            for(int r=1;r<n;r++){
                int x1 = (s[r]==t[c])?dp[r-1,c-1]:0;
                int x2 = dp[r-1,c];
                dp[r,c] = x1+x2;
            }
        }

        return dp[n-1,m-1];
    }
}
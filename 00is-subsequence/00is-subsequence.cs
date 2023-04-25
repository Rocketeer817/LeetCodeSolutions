public class Solution {
    public bool IsSubsequence(string s, string t) {
        int n = t.Length;
        int m = s.Length;

        if(m==0){
            return true;
        }

        if(n==0){
            return false;
        }

        bool[,] dp = new bool[n,m];

        dp[0,0] = (s[0]==t[0])?true:false;

        //row 0 
        for(int c=1;c<m;c++){
            dp[0,c] = false;
        }

        for(int r=1;r<n;r++){
            dp[r,0] = dp[r-1,0] || (t[r]==s[0])?true:false;
            for(int c=1;c<m;c++){
                dp[r,c] = dp[r-1,c] || (t[r]==s[c])?dp[r-1,c-1]:false;
            }
        }

        return dp[n-1,m-1];
    }
}
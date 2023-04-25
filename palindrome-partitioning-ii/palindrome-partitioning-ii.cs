public class Solution {
    public bool[,] pal;
    public int MinCut(string s) {
        BuildPalindromeChecker(s);

        int n = s.Length;

        int[] dp = new int[n+1];
        dp[n] = 0;

        for(int i=n-1;i>=0;i--){
            int ans = int.MaxValue;
            if(pal[i,n-1]==true){
                ans = 0;
            }

            for(int j=n-2;j>=i;j--){
                if(pal[i,j]==true){
                    ans = Math.Min(ans,1+dp[j+1]);
                }
            }

            dp[i] = ans;
            
        }

        return dp[0];
    }

    public void BuildPalindromeChecker(string s){
        int n = s.Length;
        pal = new bool[n,n];

        for(int r=n-1;r>=0;r--){
            for(int c = n-1;c>=r;c--){
                if(s[r]==s[c]){
                    if(r+1 <= c-1){
                        pal[r,c] = pal[r+1,c-1];
                    }
                    else{
                        pal[r,c] = true;
                    }
                }
                else{
                    pal[r,c] = false;
                }
            }
        }
    }
}
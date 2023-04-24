public class Solution {
    public int LongestValidParentheses(string s) {
        int n = s.Length;
        if(n==0){
            return 0;
        }

        int[] dp = new int[n+1];

        dp[n] = 0;
        dp[n-1] = 0;

        int ans = 0;

        Console.WriteLine("start");

        for(int i=n-2;i>=0;i--){
            Console.WriteLine(i);
            if(s[i]==')'){
                dp[i] = 0;
            }
            else{
                int k = dp[i+1];
                int j = i-1+k+2;
                if(j<n && s[j]==')'){
                    dp[i] = k+2 + ((j+1)<n?dp[j+1]:0);
                }
                else{
                    dp[i] = 0;
                }
            }
            ans = Math.Max(ans,dp[i]);
        }

        return ans;
    }


    

}

public class Solution {
    public int LongestValidParentheses(string s) {
        int n = s.Length;

        int[] dp = new int[n];

        for(int i=0;i<n;i++){
            dp[i] = -1;
        }
        
        for(int i=n-1;i>=0;i--){
            generate(s,n,i,dp);
            Console.WriteLine(dp[i]);
        }

        int maxLen = 0;

        int ptr = 0;

        int len = 0;

        while(ptr<n){
            if(dp[ptr]==0){
                len = 0;
                ptr++;
                continue;
            }
            len += dp[ptr];
            maxLen = Math.Max(maxLen,len);
            ptr += dp[ptr];
        }

        maxLen = Math.Max(maxLen,len);

        return maxLen;
    }


    public int generate(string A,int n, int idx, int[] dp){
        if(idx==n){
            return 0;
        }
        if(dp[idx]!=-1){
            return dp[idx];
        }


        if(A[idx]==')' || idx+1==n){
            dp[idx] = 0;
            return dp[idx];
        }
        
        int k = generate(A,n,idx+1,dp);
        int index = k+idx;
        if(index+1==n){
            dp[idx] = 0;
            return dp[idx];
        }

        while(index+1<n){
            if(A[index+1]==')'){
                dp[idx] = index+1-idx+1;
                break;
            }
            if(k==0){
                dp[idx]=0;
                break;
            }
            k = generate(A,n,index+1,dp);
            index = k+index;
            if(index+1==n){
                dp[idx]=0;
            }
        }
        
        
        return dp[idx];
        
    }

}

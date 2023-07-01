class Solution {
    public int distributeCookies(int[] cookies, int k) {
        int n = cookies.length;

        int[] currSum = new int[k];

        return backtracking(cookies,0,currSum,0,n,k);
    }

    public int backtracking(int[] cookies, int index,int[] currSum,int maxSum,int n,int k){
        if(index>=n){
            
            return maxSum;
        }

        int ans = Integer.MAX_VALUE;

        for(int i=0;i<k;i++){
            currSum[i] += cookies[index];
            int newMaxSum = Math.max(currSum[i],maxSum);
            ans = Math.min(ans,backtracking(cookies,index+1,currSum,newMaxSum,n,k));
            currSum[i] -= cookies[index];
        }

        return ans;
    }
}
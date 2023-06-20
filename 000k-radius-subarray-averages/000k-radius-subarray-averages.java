class Solution {
    public int[] getAverages(int[] nums, int k) {
        int n = nums.length;
        long[] ps = new long[n];

        long sum = 0;

        for(int i=0;i<n;i++){
            sum += nums[i];
            ps[i] = sum;
        }

        //for 0 to k-1 indexes the answer is -1

        int[] ans = new int[n];

        Arrays.fill(ans,-1);

        int totalSize = 2*k+1;

        if(k>=n){
            return ans;
        }
        
        for(int i=k;i<n-k;i++){
            int end = i + (k+1) - 1;
            int start = i-(k+1)+1;

            if(start==0){
                long currSum = ps[end];
                long avg = currSum/(totalSize);
                ans[i] = (int)avg;
            }
            else{
                long currSum = ps[end]-ps[start-1];
                long avg = currSum/(totalSize);
                ans[i] = (int)avg;
            }
        }
        

        return ans;
    }
}
class Solution {
    public long minCost(int[] nums, int[] cost) {

        int n = nums.length;

        int max = 0, min = 10000001;

        for(int i=0;i<n;i++){
            max = Math.max(max,nums[i]);
            min = Math.min(min,nums[i]);
        }

        int l = min, h = max;

        long ans = costToEqualize(nums,cost,n,l);

        while(l<=h){
            int mid = l + (h-l)/2;

            long cost1 = costToEqualize(nums,cost,n,mid);

            long cost2 = costToEqualize(nums,cost,n,mid+1);

            ans = Math.min(cost2,cost1);

            if(cost1>cost2){
                l = mid+1;
            }
            else{
                h = mid-1;
            }

        }

        return ans;
    }

    public long costToEqualize(int[] nums, int[] cost, int n, int x ){
        long ans = 0;

        for(int i=0;i<n;i++){
            ans += 1L*cost[i]*Math.abs(nums[i]-x);
        }

        return ans;
    }
}
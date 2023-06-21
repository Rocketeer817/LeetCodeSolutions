class Solution {
    public int minMoves2(int[] nums) {
        int n = nums.length;

        if(n==1){
            return 0;
        }

        Arrays.sort(nums);

        int mid = (n-1)/2;

        if(n%2==0){
            return getMoves(nums,n,nums[mid]);
        }
        
        return Math.min(getMoves(nums,n,nums[mid]),getMoves(nums,n,nums[mid-1]));

    }

    public int getMoves(int[] nums,int n, int x){
        int ans = 0;

        for(int i=0;i<n;i++){
            ans += Math.abs(nums[i]-x);
        }

        return ans;
    }

    
}
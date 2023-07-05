class Solution {
    public int longestSubarray(int[] nums) {
        int n = nums.length;

        int[] pc = new int[n];

        pc[0] = 0;

        for(int i=1;i<n;i++){
            if(nums[i-1]==0){
                pc[i] = 0;
            }
            else{
                pc[i] = pc[i-1]+1;
            }
        }

        int[] sc = new int[n];

        sc[n-1] = 0;

        for(int i=n-2;i>=0;i--){
            if(nums[i+1]==0){
                sc[i] = 0;
            }
            else{
                sc[i] = sc[i+1]+1;
            }
        }

        int ans = 0;

        for(int i=0;i<n;i++){
            ans = Math.max(pc[i]+sc[i],ans);
        }

        return ans;
    }
}
class Solution {
    public int searchInsert(int[] nums, int target) {
        int l = 0;
        int h = nums.length-1;

        int ans = -1;

        while(l<=h){
            int mid = (l+h)/2;

            if(nums[mid]<=target){
                l = mid+1;
                ans = mid;
            }
            else{
                h = mid-1;
            }
        }

        return (ans>=0 && nums[ans]==target)?ans : ans+1;
    }
}
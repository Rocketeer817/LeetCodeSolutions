class Solution {
    public int firstMissingPositive(int[] nums) {
        int n = nums.length;

        int i =0;

        while(i<n){
            int exp = nums[i]-1;
            if(nums[i]>0 && nums[i]<=n && nums[i]!=nums[exp]){
                int temp = nums[i];
                nums[i] = nums[exp];
                nums[exp] = temp;
            }
            else{
                i++;
            }
        }


        for(int j=0;j<n;j++){
            if(nums[j]!=j+1){
                return j+1;
            }
        }

        return n+1;
    }
}
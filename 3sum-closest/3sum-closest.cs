public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        int n = nums.Length;
        Array.Sort(nums);

        int closest = int.MaxValue;
        int ans = int.MaxValue;

        for(int i=0;i+2<n;i++){
            int req = target-nums[i];
            int sum = TwoSumClosest(nums,req,i)+nums[i];
            int diff = Math.Abs(target-sum);
            if(diff<closest){
                closest = diff;
                ans = sum;
            }
        }

        return ans;
    }

    public int TwoSumClosest(int[] nums, int target,int index){
        int closest = int.MaxValue;
        int ans = int.MaxValue;

        int l = index+1;
        int h = nums.Length-1;

        while(l<h){
            int sum = nums[l]+nums[h];
            int diff = Math.Abs(target-sum);
            if(diff<closest){
                closest = diff;
                ans = sum;
            }

            if(sum>target){
                h--;
            }
            else if(sum<target){
                l++;
            }
            else{
                return sum;
            }
        }

        return ans;
    }
}
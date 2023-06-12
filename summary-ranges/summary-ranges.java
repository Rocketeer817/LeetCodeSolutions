class Solution {
    public List<String> summaryRanges(int[] nums) {
        int n = nums.length;

        List<String> ans = new ArrayList<>();
        int i = 0;
        while(i<n){
            int start = nums[i];
            int end = start;
            i++;
            while(i<n && nums[i]==nums[i-1]+1){
                end = nums[i];
                i++;
            }
            String range = (end==start)?start+"" : start+"->"+end;
            ans.add(range);
        }

        return ans;
    }
}
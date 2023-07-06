class Solution {
    public int minSubArrayLen(int target, int[] nums) {
        //[0,r] -> ts , consider [0,l] -> s where l<r such that ts-s-target >= 0 => ts-target >= s

        TreeMap<Integer,Integer> map = new TreeMap<Integer,Integer>();

        int n = nums.length;

        int len = Integer.MAX_VALUE;

        int sum = 0;

        map.put(0,0);

        for(int i=0;i<n;i++){
            sum += nums[i];
            if(sum>=target){
                int req = sum-target;
                int key = map.floorKey(req);
                int value = map.get(key);
                int flen = (i+1) - value;
                len = Math.min(flen,len);
            }

            map.put(sum,i+1);
        }

        return len<=n? len : 0;


    }
}
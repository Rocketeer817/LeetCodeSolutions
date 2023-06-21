class Solution {
    public List<Long> minOperations(int[] nums, int[] queries) {
        List<Long> ans = new ArrayList<Long>();

        int n = nums.length;

        Arrays.sort(nums);

        long[] ps = new long[n];

        ps[0] = nums[0];
        for(int i=1;i<n;i++){
            ps[i] = ps[i-1]+nums[i];
        }

        for(int i=0;i<queries.length;i++){
            ans.add(cost(nums,ps,queries[i]));
        }

        return ans;
    }

    public long cost(int[] nums,long[] ps,int x){
        int n = nums.length;

        long ans = 0;
        
        int index = floor(nums,x);

        // 0 to index-1 => index*x - ps[index-1]
        long left = ((long)x*index) - (index>0?ps[index-1]:0);

        //index to n-1 => ps[n-1]-ps[index-1] - (n-1-index+1)*x
        long right = (index>0?ps[n-1]-ps[index-1]: ps[n-1]) - ((long)x * (n-index));

        ans = left + right;

        return ans;
    }

    public int floor(int[] nums, int x){
        int l = 0;
        int h = nums.length-1;

        int ans = h+1;

        while(l<=h){
            int mid = l + (h-l)/2;
            if(nums[mid]>=x){
                ans = mid;
                h = mid-1;
            }
            else{
                l = mid+1;
            }
        }

        return ans;
    }
}
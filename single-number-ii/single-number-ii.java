class Solution {
    public int singleNumber(int[] nums) {
        int n = nums.length;
        int ans = 0;

        int k = -4;

        //System.out.println((1<<31));

        

        for(int i=31;i>=0;i--){
            int setBitCount = 0;
            for(int j=0;j<n;j++){
                if((nums[j]&(1<<i))!=0){
                    setBitCount++;
                }
            }
            //System.out.println("At bit "+i+" the setbit counter is "+setBitCount);
            if(setBitCount%3 == 1){
                //System.out.println("At bit "+i+" the bit is set");
                ans |= (1<<i);
            }
        }

        return ans;
    }
}
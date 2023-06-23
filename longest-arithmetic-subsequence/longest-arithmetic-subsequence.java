class Solution {

    List<Map<Integer,Integer>> dp ;
    public int longestArithSeqLength(int[] nums) {
        int n = nums.length;

        dp = new ArrayList<Map<Integer,Integer>>();

        for(int i=0;i<n;i++){
          dp.add(new HashMap<>());
        }



        int ans = 2;

        /* bottom up approach
        for(int i=0;i+1<n;i++){

            for(int j=i+1;j<n;j++){
              int diff = nums[j] - nums[i];
              int curr = bottomup(nums,j,diff,n) + 2;
              ans = Math.max(ans,curr);
            }

        }*/

        for(int i=n-1;i>=0;i--){
          for(int j=n-1;j>i;j--){
            int diff = nums[j] - nums[i];
            int curr = dp.get(j).getOrDefault(diff,0);
            ans = Math.max(ans,curr+2);
            dp.get(i).put(diff,1+curr);
          }
        }

        return ans;
    }

    public int bottomup(int[] nums, int index, int diff,int n){
      
      if(index>=n){
        return 0;
      }

      if(dp.get(index).containsKey(diff)){
        return dp.get(index).get(diff);
      }

      int ans = 0;

      for(int j = index+1;j<n;j++){
        int curr = 0;

        if(nums[j]-nums[index] == diff){
          curr += bottomup(nums,j,diff,n)+1;
        }

        //System.out.println(curr + "\t" + j + "\t" + diff);

        ans = Math.max(curr,ans);

      }

      dp.get(index).put(diff,ans);

      return ans;

    }
}
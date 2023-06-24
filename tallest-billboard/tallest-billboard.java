class Solution {

    private long mod;
    public int tallestBillboard(int[] rods) {
        //states : curr index, set1 sum, set2 sum
        mod = (long)Math.pow(10,4);

        int n = rods.length;

        Map<Integer,Integer> dp = new HashMap<Integer,Integer>();

        int[] firstHalf = new int[n/2];

        for(int i=0;i<n/2;i++){
            firstHalf[i] = rods[i];
        }

        bottomup(firstHalf, n/2, 0, 0, 0, dp);

        Map<Integer,Integer> dp1 = new HashMap<Integer,Integer>();

        int[] secondHalf = new int[n-n/2];

        for(int i=n/2;i<n;i++){
            secondHalf[i-n/2] = rods[i];
        }        

        bottomup(secondHalf, n - n/2, 0, 0, 0, dp1);

        int ans = 0;

        for(int x : dp.keySet()){
            int y = 0 - x;
            if(dp1.containsKey(y)){
                ans = Math.max(ans, dp.get(x)+dp1.get(y));
            }
        }

        return ans;

    }


    public void bottomup( int[] rods, int n, int index ,int set1, int set2,Map<Integer,Integer> dp){
        //System.out.println(index + "\t" + set1 + "\t" +set2);
        if(index>=n){
            
            
            int h = Math.max(dp.getOrDefault(set1-set2,0),set1);
            dp.put(set1-set2,h);

            return;
            
        }

        //System.out.println(index + "\t" + set1 + "\t" +set2);

        bottomup(rods,n,index+1,set1,set2,dp);

        bottomup(rods,n,index+1,set1+rods[index],set2,dp);

        bottomup(rods,n,index+1,set1,set2+rods[index],dp);

    }
}
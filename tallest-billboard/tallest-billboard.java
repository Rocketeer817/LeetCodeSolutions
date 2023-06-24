class Solution {

    private long mod;
    public int tallestBillboard(int[] rods) {
        //states : curr index, set1 sum, set2 sum
        mod = (long)Math.pow(10,4);

        int n = rods.length;

        Map<Integer,Integer> dp = new HashMap<Integer,Integer>();
        dp.put(0,0);

        for(int r : rods){
            
            Map<Integer,Integer> newDp = new HashMap<>(dp);

            for(Map.Entry<Integer,Integer> entry : dp.entrySet()){
                int diff = entry.getKey();
                int taller = entry.getValue();
                int shorter = taller - diff;

                int newTaller = newDp.getOrDefault(diff+r,0);
                newDp.put(diff+r, Math.max(newTaller,taller+r));

                int newDiff = Math.abs(shorter + r - taller);
                newTaller = Math.max(shorter+r , taller);
                newDp.put(newDiff, Math.max(newTaller, newDp.getOrDefault(newDiff,0)));
            }

            dp = newDp;
        }

        
        return dp.getOrDefault(0,0);

        

    }


    
}
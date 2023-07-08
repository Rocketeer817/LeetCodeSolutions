class Solution {
    public long putMarbles(int[] weights, int k) {
        int n = weights.length;

        long[] weightPairs = new long[n-1];

        for(int i=0;i<n-1;i++){
            weightPairs[i] = weights[i]+weights[i+1];
        }

        Arrays.sort(weightPairs);

        long sum = 0l;

        for(int i=0;i<k-1;i++){
            long currMax = weightPairs[n-2-i];
            long currMin = weightPairs[i];

            sum += (currMax - currMin);


        }

        return sum;
    }
}
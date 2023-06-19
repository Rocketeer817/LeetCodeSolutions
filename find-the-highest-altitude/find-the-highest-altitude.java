class Solution {
    public int largestAltitude(int[] gain) {
        int n = gain.length;
        int[] peak = new int[n+1];

        peak[0] = 0;

        int curr = 0;

        int ans = 0;

        for(int i=0;i<n;i++){
            curr = gain[i]+peak[i];
            peak[i+1] = curr;

            ans = Math.max(ans,curr);
        }

        return ans;
    }
}
class Solution {
    public int maxValue(int n, int index, int maxSum) {
        int l = 1;
        int r = maxSum;

        int ans = -1;

        while(l<=r){
            int mid = l + (r-l)/2;
            if(check((long)n,(long)index,(long)maxSum,(long)mid)){
                ans = mid;
                l = mid+1;
            }
            else{
                r = mid-1;
            }
        }

        return ans;
    }

    public boolean check(long n, long index,long maxSum,long val){
        long totalSum = 0;
        //left side
        long leftIdx = index-val+1;

        if(leftIdx<0){
            totalSum += ((val+val-index)*(index+1))/2 ;
        }
        else{
            totalSum += leftIdx + ((val+1)*val)/2;
        }

        //right side 
        long rightIdx = index-1+val;

        if(rightIdx>n-1){
            long lastValue = val-((n-index-1));
            totalSum += ((lastValue+val)*(n-index))/2;
        }
        else{
            totalSum += (n-rightIdx-1) + ((val+1)*val)/2;
        }

        totalSum -= val;

        return totalSum<=maxSum;


    }
}
public class Solution {
    public int Trap(int[] h) {
        /*
           |
           |           |
           |           |   
           |           |   
           |x1   i,x.  |x2 => at i the height is x , then rainwater trapped at i pos is Min(x1,x2)-x where x1 and x2 are the maximums on left side and right side of i respectively
        */

        int n = h.Length;
        int[] leftMax = new int[n];
        int lm = 0;
        for(int i=0;i<n;i++){
            leftMax[i] = lm;
            lm = Math.Max(lm,h[i]);
        }

        int[] rightMax = new int[n];
        int rm = 0;
        for(int i=n-1;i>=0;i--){
            rightMax[i] = rm;
            rm = Math.Max(rm,h[i]);
        }

        int area = 0;

        for(int i=0;i<n;i++){
            int ph = Math.Min(leftMax[i],rightMax[i]);
            int trapped = ph-h[i];
            if(trapped>0){
                area += trapped;
            }
        }

        return area;
    }
}
class Solution {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.length;
        int n = nums2.length;

        int midLen = (m+n+1)/2;

        if(n<m){
            int[] temp = nums2;
            nums2 = nums1;
            nums1 = temp;

            int tempLen = n;
            n = m;
            m = tempLen;

        }

        int l = 0 , h = m;

        while(l<=h){
            int mid = l + (h-l)/2 ;
            int pA = mid;
            int pB = midLen-mid;

            int s1 = (pA>0) ? nums1[pA-1] : Integer.MIN_VALUE ;
            int s2 = (pB>0) ? nums2[pB-1] : Integer.MIN_VALUE ; 

            int l1 = (pA<m)? nums1[pA] : Integer.MAX_VALUE;
            int l2 = (pB<n)? nums2[pB] : Integer.MAX_VALUE;

            //System.out.println(pA + "\t" + pB + "\t" + s1 + "\t" + l1 +"\t"+ s2 + "\t" + l2);

            if(s1<=l2 && s2<=l1){
                if((m+n)%2==0){
                    double m1 = Math.max(s1,s2);
                    double m2 = Math.min(l1,l2);
                    return (m1+m2)/2;
                }
                else{
                    double m1 = Math.max(s1,s2);
                    return m1;
                }
            }
            else if(s2<=l1){
                h = mid-1;
            }
            else{
                l = mid+1;
            }

            //System.out.println("next : " + "\t" + l + "\t" + h);
        }

        return -1;


    }

    
}
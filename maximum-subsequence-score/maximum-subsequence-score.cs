public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        //Brute force : write k loops and select k indexes and get maximum of the scores calculated
        //Idea 2 : There is no relation between nums1[i] and nums2[i] so we will have to fix one of them 
        //i.e. one way is to fix the min of k nums2[j] and find the max sum for that case.

        int n = nums2.Length;

        int[][] nums = new int[n][];

        for(int i=0;i<n;i++){
            nums[i] = new int[2];
            nums[i][0] = nums1[i];
            nums[i][1] = nums2[i];
        }

        //Console.WriteLine("Here");

        Array.Sort(nums,(x,y)=>y[1].CompareTo(x[1]));

        PriorityQueue<int,int> pq = new PriorityQueue<int,int>();

        long sum =0;

        //Console.WriteLine("Here");

        //select nums[k-1][1] as min value of the selected elements i0,i1,...,ik-1
        for(int i=0;i<k;i++){
            sum += nums[i][0];
            pq.Enqueue(nums[i][0],nums[i][0]);
        }

        long ans = sum*nums[k-1][1];
        //Console.WriteLine(ans);

        for(int i=k;i<n;i++){
            //if nums[i][1] is the min and the selected bunch are in the range of 0 , i
            sum += nums[i][0]-pq.Dequeue();
            pq.Enqueue(nums[i][0],nums[i][0]);

            ans = Math.Max(ans,sum*nums[i][1]);
            //Console.WriteLine($"{sum*nums[i][1]} , {ans}");
        }

        return ans;

    }
}
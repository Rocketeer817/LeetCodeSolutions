public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int,int> freq = new Dictionary<int,int>();
        for(int i=0;i<nums.Length;i++){
            if(!freq.ContainsKey(nums[i])){
                freq[nums[i]] = 1;
            }
            else{
                freq[nums[i]]++;
            }
        }

        PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((x, y) => y - x));

        foreach(int key in freq.Keys){
            pq.Enqueue(key,freq[key]);
        }

        int[] ans = new int[k];
        for(int i=0;i<k;i++){
            ans[i] = pq.Dequeue();
        }

        return ans;
    }
}
public class KthLargest {

    private PriorityQueue<int,int> pq ;
    private int K;

    public KthLargest(int k, int[] nums) {
        pq = new PriorityQueue<int,int>();
        K = k;

        for(int i=0;i<nums.Length;i++){
            if(pq.Count<k){
                pq.Enqueue(nums[i],nums[i]);
            }
            else if(pq.Peek()<nums[i]){
                pq.Dequeue();
                pq.Enqueue(nums[i],nums[i]);
            }
        }
    }
    
    public int Add(int val) {
        if(pq.Count<K){
            pq.Enqueue(val,val);
        }
        else if(pq.Peek()<val){
            pq.Dequeue();
            pq.Enqueue(val,val);
        }

        return pq.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
public class Solution {
    public int LastStoneWeight(int[] stones) {
        //Custom comparator using lambda function
        PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((a,b)=>b.CompareTo(a)));
        for(int i=0;i<stones.Length;i++){
            pq.Enqueue(stones[i],stones[i]);
        }

        while(pq.Count>1){
            int first = pq.Dequeue();
            int second = pq.Dequeue();

            if(first>second){
                pq.Enqueue(first-second,first-second);
            }
        }

        return (pq.Count==1)?pq.Dequeue():0;
    }
}
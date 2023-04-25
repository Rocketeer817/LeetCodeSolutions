public class SmallestInfiniteSet {
    private PriorityQueue<int,int> pq ;
    private HashSet<int> set ;
    public SmallestInfiniteSet() {
        pq = new PriorityQueue<int,int>();
        set = new HashSet<int>();
        for(int i=1;i<=1000;i++){
            set.Add(i);
            pq.Enqueue(i,i);
        }
    }
    
    public int PopSmallest() {
        // PrioirityQueue is needed to pop the smallest number
        if(set.Count==0){
            return 0;
        }
        int x = pq.Dequeue();
        set.Remove(x);
        return x;
    }
    
    public void AddBack(int num) {
        //hashset needed to verify if num is already present
        if(!set.Contains(num)){
            set.Add(num);
            pq.Enqueue(num,num);
        }
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */
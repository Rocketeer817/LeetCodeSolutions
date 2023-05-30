public class MyHashSet {
    private List<int> set;
    public MyHashSet() {
        set = new List<int>();    
    }
    
    public void Add(int key) {
        int pos = Find(key);
        if(pos<0 || set[pos]!=key){
            set.Insert(pos+1,key);
        }
    }
    
    public void Remove(int key) {
        int pos = Find(key);
        if(pos>=0 && set[pos]==key){
            set.RemoveAt(pos);
        }
    }
    
    public bool Contains(int key) {
        int pos = Find(key);
        return pos>=0 && set[pos]==key;
    }

    private int Find(int key){
        int l = 0;
        int h = set.Count-1;

        int ans = -1;

        while(l<=h){
            int mid = l + (h-l)/2;
            if(set[mid]<=key){
                l = mid+1;
                ans = mid;
            }
            else if(set[mid]>key){
                h = mid-1;
            }
        }

        return ans;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
public class MyHashSet {
    private List<int> set;
    public MyHashSet() {
        set = new List<int>();    
    }
    
    public void Add(int key) {
        if(!Contains(key)){
            set.Add(key);
        }
    }
    
    public void Remove(int key) {
        set.Remove(key);
    }
    
    public bool Contains(int key) {
        return set.Contains(key);
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
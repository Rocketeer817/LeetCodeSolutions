class LRUCache {

    Node head ;
    Node tail;

    Map<Integer,Node> map ;

    int cap;

    public LRUCache(int capacity) {
        this.cap = capacity;
        this.head = null;
        this.tail = null;
        map = new HashMap<>();
    }
    
    public int get(int key) {
        //System.out.println(key);
        //search if key exists or not
        if(map.containsKey(key)==false){
            return -1;
        }

        //key exists. Now find the value of the key
        Node node = map.get(key);
        put(key,node.value);

        return node.value;
    }
    
    public void put(int key, int value) {
        //System.out.println(key + "," + value);
        //if the lru contains the key
        if(map.containsKey(key)){
            Node node = map.get(key);
            remove(node);
            node.value = value;
            add(node);
            return;
        }

        Node newNode = new Node(key,value);
        add(newNode);
    }

    private void remove(Node node){
        map.remove(node.key);
        //case 1 : if node is head and tail
        if(node==head && node==tail){
            head = null;
            tail = null;
        }
        //case 2 : if node is head 
        else if(node==head){
            //move head ptr 1 move forward
            head = node.next;
            node.next = null;
            head.prev = null;
        }
        else if(node==tail){
            //move tail ptr 1 move backward
            tail = node.prev;
            node.prev = null;
            tail.next = null;
        }
        else{
            Node next = node.next;
            Node prev = node.prev;

            //connect next and prev by skipping node
            next.prev = prev;
            prev.next = next;

            node.next = null;
            node.prev = null;
        }

    }

    private void add(Node node){
        map.put(node.key,node);
        //case 1: if head and tail are null
        if(head==null && tail==null){
            head = node;
            tail = node;
        }
        //case 2 : add the node at the end of tail and reassign tail
        else{
            tail.next = node;
            node.prev = tail;
            tail = node;
            
        }

        //verify that the LRU is within capacity
        if(map.size()>cap){
            //remove head
            Node nodeToRemove = head;
            remove(nodeToRemove);
        }
    }
}

class Node{
    public int key;
    public int value;

    public Node next;
    public Node prev;

    public Node(int key,int value){
        this.key = key;
        this.value = value;
        this.next = null;
        this.prev = null;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */
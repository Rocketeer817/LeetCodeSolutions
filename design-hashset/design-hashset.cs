public class MyHashSet {
    private Node root;

    public MyHashSet() {
        root = null;
    }
    
    public void Add(int key) {
        if(root==null){
            root = new Node(key);
            return;
        }
        Insert(root,key);
    }
    
    public void Remove(int key) {
        Remove(null,root,key,true);
    }
    
    public bool Contains(int key) {
        return Find(root,key);
    }

    public bool Find(Node node, int key){
        if(node == null){
            return false;
        }
        if(node.val == key){
            return true;
        }

        return node.val>key?Find(node.left,key):Find(node.right,key);
    }

    public void Insert(Node node, int key){
        if(node.val==key){
            return;
        }

        if(node.val>key){
            if(node.left==null){
                node.left = new Node(key);
                return;
            }
            else{
                Insert(node.left,key);
            }
        }
        else{
            if(node.right==null){
                node.right = new Node(key);
                return;
            }
            else{
                Insert(node.right,key);
            }
        }
    }

    public void Remove(Node parent,Node node, int key,bool left){
        if(node==null){
            return;
        }
        if(node.val == key){
            
            if(node.left == null && node.right == null){
                if(parent==null){
                    root = null;
                }
                else{
                    RemoveNode(parent,node,left);
                }               
            }

            int x = FindInorderSuccessor(node.right);

            if(x==-1){
                if(parent==null){
                    root = node.left;
                }
                else if(left){                   
                    parent.left = node.left;                                       
                }
                else{
                    parent.right = node.left;
                }
            }
            else{
                node.val = x;
                Remove(node,node.right,x,false);
            }
            
            return;
        }

        if(node.val<key){
            Remove(node,node.right,key,false);
        }
        else{
            Remove(node,node.left,key,true);
        }


    }

    public void RemoveNode(Node parent,Node node,bool left){
        if(left){
            parent.left = null;
        }
        else{
            parent.right = null;
        }
    }

    public int FindInorderSuccessor(Node node){
        if(node==null){
            return -1;
        }

        if(node.left == null){
            return node.val;
        }

        return FindInorderSuccessor(node.left);
    }

}

public class Node{
    public int val;
    public Node left;
    public Node right;

    public Node(int x){
        val = x;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
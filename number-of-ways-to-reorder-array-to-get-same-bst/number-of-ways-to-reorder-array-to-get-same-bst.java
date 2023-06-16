class Solution {
    
    Map<Node,int[]> map;

    Map<Node,Long> mapWays;

    long mod = (long)Math.pow(10,9)+7;

    public int numOfWays(int[] nums) {
        int n = nums.length;

        map = new HashMap<>();

        mapWays = new HashMap<>();

        Node root = new Node(nums[0]);

        for(int i=1;i<n;i++){
            insert(root,nums[i]);
        }

        int k = noOfChildren(root);

        if(k==n){
            System.out.println("Ok");
        }
        else{
            System.out.println("Warning");
        }



        k = (int)ways(root);

        /*for(Map.Entry<Node,Long> e : mapWays.entrySet()){
            System.out.println(e.getKey().val + " ::: " + e.getValue());
        }*/

        return k-1;
        
    }

    public long ways(Node root){
        if(root == null){
            return 1;
        }

        if(mapWays.containsKey(root)){
            return mapWays.get(root);
        }

        long left = ways(root.left);
        long right = ways(root.right);

        long lc = map.get(root)[0];
        long rc = map.get(root)[1];

        long tc = map.get(root)[2];

        long ans = calculateCustomValue(tc,lc,rc);

        ans = (ans*left)%mod;
        ans = (ans*right)%mod;

        mapWays.put(root,ans);

        return ans;
    }

    public long factorial(long c){
        long ans = 1;
        for(int i=2;i<=c;i++){
            ans = (ans*i)%mod;
        }

        return ans;
    }

    public long calculateCustomValue(long tc,long lc, long rc){
        long numerator = factorial(tc-1);
        //System.out.println(tc-1 +" -> " +numerator);
        long denominator = (factorial(lc) * factorial(rc))%mod;
        //System.out.println(lc+","+rc +" -> " +denominator);

        long inverse = inverseModulo(denominator);

        return (numerator * inverse)%mod;
    }

    public long inverseModulo(long k){
        return pow(k,mod-2,mod);
    }

    public long pow(long a, long b, long mod){
        if(b==0){
            return 1;
        }

        long half = pow(a,b/2,mod);

        long temp = (half*half)%mod;

        if(b%2==1){
            return (temp*a)%mod;
        }

        return temp;
    }

    public Node insert(Node root, int val){
        if(root==null){
            return new Node(val);
        }

        if(root.val < val){
            root.right = insert(root.right,val);
        }
        else{
            root.left = insert(root.left,val);
        }

        return root;
        
    }

    public int noOfChildren(Node root){
        if(root==null){
            return 0;
        }

        if(map.containsKey(root)){
            return map.get(root)[2];
        }

        int lc = noOfChildren(root.left) ;
        int rc = noOfChildren(root.right);

        int tc = lc + rc + 1;

        map.put(root,new int[]{lc,rc,tc});

        return tc;
    }
}

class Node{
    int val;
    Node left;
    Node right;

    public Node(int v){
        this.val = v;
        left = null;
        right = null;
    }
}
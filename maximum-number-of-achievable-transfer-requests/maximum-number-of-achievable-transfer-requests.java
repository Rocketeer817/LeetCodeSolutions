class Solution {
    private int ans;

    public int maximumRequests(int n, int[][] requests) {
        ans = 0;
        List<int[]> curr = new ArrayList<>();
        backtracking(n,requests,0,curr);

        return ans;
    }

    public void backtracking(int n, int[][] requests, int index, List<int[]> curr){
        //base condition
        if(index>=requests.length){
            //System.out.println(curr.size());
            if(check(curr)){
                ans = Math.max(ans,curr.size());
            }
            return;
        }


        //Select the value for index
        curr.add(requests[index]);

        backtracking(n,requests,index+1,curr);

        // backtracking for index

        curr.remove(curr.size()-1);

        //Case of not selecting request at this index.
        backtracking(n,requests,index+1,curr);

        
    }

    public boolean check(List<int[]> arr){
        int n = arr.size();

        Map<Integer,Integer> map = new HashMap<>();

        for(int i=0;i<n;i++){
            int a = arr.get(i)[0];
            int b = arr.get(i)[1];
            map.put(a,map.getOrDefault(a,0)-1);
            map.put(b,map.getOrDefault(b,0)+1);
            //System.out.print(a+","+b+" ");
        }

        //System.out.println();
        //System.out.println("Map size "+map.size());

        for(int key : map.keySet()){
            if(map.get(key)!=0){
                return false;
            }
        }

        //System.out.println(arr.size());

        return true;
    }
}
class Solution {
    public List<Integer> eventualSafeNodes(int[][] graph) {
        int n = graph.length;
        Set<Integer> set = new HashSet<>();
        boolean[] vis = new boolean[n];

        Arrays.fill(vis,false);

        List<Integer> ans = new ArrayList<>();

        for(int i=0;i<n;i++){
            if(bfs(graph,i,set,vis)){
                ans.add(i);
            }
        }

        return ans;
    }

    public boolean bfs(int[][] graph, int idx, Set<Integer> set, boolean[] vis){

        if(vis[idx]==true){
            return set.contains(idx);
        }

        //System.out.println("Checking "+idx);

        vis[idx] = true;

        for(int j=0;j<graph[idx].length;j++){
            int target = graph[idx][j];

            //System.out.println(idx+"->"+target);
            boolean flag = bfs(graph,target,set,vis);

            if(flag == false){
                return false;
            }
        }

        set.add(idx);

        return true;

    }
}
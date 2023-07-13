class Solution {
    public boolean canFinish(int numCourses, int[][] prerequisites) {
        List<Set<Integer>> list = new ArrayList<>();
        for(int i=0;i<numCourses;i++){
            list.add(new HashSet<>());
        }

        for(int i=0;i<prerequisites.length;i++){
            list.get(prerequisites[i][0]).add(prerequisites[i][1]);
        }

        boolean[] noLoop = new boolean[numCourses];

        for(int i=0;i<numCourses;i++){
            boolean[] vis = new boolean[numCourses];
            Arrays.fill(vis,false);
            boolean[] inStack = new boolean[numCourses];
            Arrays.fill(inStack,false);
            if(dfs(list,i,vis,inStack,noLoop)==false){
                return false;
            }

            noLoop[i] = true;

        }

        return true;
    }

    public boolean dfs(List<Set<Integer>> graph,int idx,boolean[] vis,boolean[] inStack,boolean[] noLoop){
        if(inStack[idx]==true){
            return false;
        }

        if(noLoop[idx] == true){
            return true;
        }

        vis[idx] = true;
        
        inStack[idx] = true;

        for(int i : graph.get(idx)){
            
            if(dfs(graph,i,vis,inStack,noLoop) == false){
                return false;
            }   
            
        }

        inStack[idx] = false;

        noLoop[idx] = true;

        return true;
    }
}
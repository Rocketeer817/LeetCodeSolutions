class Solution {
    public double maxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        Map<Integer,List<Node>> graph = new HashMap<Integer,List<Node>>();

        for(int i=0;i<n;i++){
            graph.put(i,new ArrayList<Node>());
        }

        for(int i=0;i<edges.length;i++){
            int s = edges[i][0], dest = edges[i][1];
            double edge = succProb[i];

            graph.get(s).add(new Node(dest, edge));
            //System.out.println(s + "\t" +dest);
            graph.get(dest).add(new Node(s, edge));
            //System.out.println(dest + "\t" +s);
        }

        PriorityQueue<Node> pq = new PriorityQueue<Node>((a,b)->Double.compare(b.edge,a.edge));
        pq.offer(new Node(start,1));
        boolean[] vis = new boolean[n];
        Arrays.fill(vis,false);

        double[] ans = new double[n];
        Arrays.fill(ans,0);

        while(pq.isEmpty()==false){

            Node curr = pq.poll();

            //System.out.println(curr.node + "\t" +curr.edge);

            if(vis[curr.node]==true){
                continue;
            }

            vis[curr.node] = true;
            ans[curr.node] = Math.max(curr.edge, ans[curr.node]);

            for(Node t : graph.get(curr.node)){
                //System.out.println("Process for " + curr.node + "\t" +t.node);
                if(vis[t.node] == false){                   
                    pq.offer(new Node(t.node,curr.edge*t.edge));
                }
            }

        }

        return ans[end];

    }
}

class Node{
    public int node;
    public double edge;

    public Node(int n, double e){
        this.node = n;
        this.edge = e;
    }
}
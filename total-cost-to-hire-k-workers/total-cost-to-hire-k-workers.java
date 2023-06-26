class Solution {
    public long totalCost(int[] costs, int k, int cd) {
        int n = costs.length;

        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a,b)-> (a[0]==b[0])?a[1]-b[1]:a[0]-b[0]);
        int l = 0;
        while(l<cd){
            pq.add(new int[]{costs[l],l});
            l++;
        }
        l--;

        int cnt = 0;
        int r = n-1;
        while(r>l && cnt<cd){
            pq.add(new int[]{costs[r],r});
            cnt++;
            r--;
        }
        r++;

        long total = 0;

        cnt = 0;

        while(cnt<k){
            int[] temp = pq.peek();
            pq.poll();
            //System.out.println(temp[0]+"\t"+temp[1]);
            total += temp[0];
            cnt++;

            //System.out.println(temp[1]+"\t"+l+"\t"+r);

            if(l+1<r && temp[1]<=l){
                l++;
                //System.out.println("adding "+costs[l]+"\t"+l);
                pq.add(new int[]{costs[l],l});
            }
            else if(l<r-1 && temp[1]>=r){
                r--;
                pq.add(new int[]{costs[r],r});
            }
        }

        return total;


    }
}
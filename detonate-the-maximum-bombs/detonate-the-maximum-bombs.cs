public class Solution {

    public int MaximumDetonation(int[][] bombs) {
        int max = 1;
        for(int i=0;i<bombs.Length;i++){
            max = Math.Max(bfs(bombs,bombs[i][0],bombs[i][1],bombs[i][2],i) , max );
        }

        return max;


    }

    public int bfs(int[][] bombs , int x, int y, int r,int index){
        HashSet<int> hs = new HashSet<int>();

        Queue<int[]> q = new Queue<int[]>();

        int count = 1;

        q.Enqueue(new int[]{x,y,r});
        hs.Add(index);

        while(q.Count>0){
            int[] temp = q.Dequeue();

            int cx = temp[0], cy = temp[1], cr = temp[2];
            
            int lx = cx-cr, ly = cy+cr;

            /*
            for(int i = cx-cr;i<=cx+cr;i++){
                for(int j = cy-cr;j<=cy+cr;j++){
                    if(WithinRange(i,j,cx,cy,cr) && !(hsx.Contains(i) && hsy.Contains(y)) ){
                        int index = FindBomb(i,j,bombs);
                        if(index>=0){
                            q.Enqueue(bombs[index]);
                            hsx.Add(i);
                            hsy.Add(j);
                            count++;
                        }
                    }
                }
            }*/

            for(int i=0;i<bombs.Length;i++){
                int nx = bombs[i][0], ny = bombs[i][1];
                if( !(hs.Contains(i)) && WithinRange(nx,ny,cx,cy,cr)){
                    q.Enqueue(bombs[i]);
                    hs.Add(i);
                    count++;
                }
            }
        }

        return count;
    }

    public bool WithinRange(int x, int y,int cx, int cy, int cr){
        long dis = (long)Math.Pow(Math.Abs(x-cx),2) + (long)Math.Pow(Math.Abs(y-cy),2);
        long rSq = (long)Math.Pow(cr,2);

        return dis<=rSq;
    }

    public int FindBomb(int x, int y,int[][] bombs){
        
        for(int i=0;i<bombs.Length;i++){
            if(x==bombs[i][0] && y==bombs[i][1]){
                return i;
            }
        }

        return -1;
    }


}
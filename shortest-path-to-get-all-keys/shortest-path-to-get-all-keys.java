class Solution {
    public int shortestPathAllKeys(String[] grid) {
        int m = grid.length, n = grid[0].length();

        Queue<int[]> q = new LinkedList<>();

        int[][] moves = new int[][]{{0,1},{1,0},{0,-1},{-1,0}};

        Map<Integer, Set<Pair<Integer,Integer>>> seen = new HashMap<>();

        Set<Character> keySet = new HashSet<>();
        Set<Character> lockSet = new HashSet<>();

        int allKeys = 0;
        int sx = -1, sy = -1;

        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++){
                char cell = grid[i].charAt(j);
                if(cell>='a' && cell<='f'){
                    allKeys = allKeys | (1<<(cell-'a'));
                    keySet.add(cell);
                }
                if(cell>='A' && cell<='F'){
                    lockSet.add(cell);
                }
                if(cell=='@'){
                    sx = i;
                    sy = j;
                }
            }
        }

        q.offer(new int[]{sx,sy,0,0});
        seen.put(0, new HashSet<>());
        seen.get(0).add(new Pair<>(sx,sy));

        while(!q.isEmpty()){
            int[] curr = q.poll();
            int r = curr[0], c = curr[1], keys = curr[2], dist = curr[3];

            for(int[] move : moves){
                int nr = r+move[0], nc = c+move[1];

                if(nr>=0 && nr<m && nc>=0 && nc<n && grid[nr].charAt(nc) != '#'){
                    char cell = grid[nr].charAt(nc);


                    //if cell is a key.
                    if(keySet.contains(cell)){
                        
                        if((1<<(cell-'a') & keys)!=0){
                            continue;
                        }

                        int newKeys = (keys|(1<<(cell-'a')));

                        if(newKeys==allKeys){
                            return dist+1;
                        }

                        if(seen.containsKey(newKeys)==false){
                            seen.put(newKeys,new HashSet<>());
                        }

                        seen.get(newKeys).add(new Pair<>(nr,nc));
                        q.offer(new int[]{nr,nc,newKeys,dist+1});


                    }

                    //if cell is a lock
                    if(lockSet.contains(cell) && ((keys&(1<<(cell-'A')))==0)){
                        continue;
                    }

                    else if(!seen.get(keys).contains(new Pair<>(nr,nc))){
                        seen.get(keys).add(new Pair<>(nr,nc));
                        q.offer(new int[]{nr,nc,keys,dist+1});
                    }

                    

                }


            }
        }

        return -1;

    }
}
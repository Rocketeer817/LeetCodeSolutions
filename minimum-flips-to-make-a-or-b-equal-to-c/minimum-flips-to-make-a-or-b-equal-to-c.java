class Solution {
    public int minFlips(int a, int b, int c) {
        int ans = 0;
        //take 31 bits
        for(int i=0;i<31;i++){
            int bit1 = (a&(1<<i))>0?1:0;
            int bit2 = (b&(1<<i))>0?1:0;

            int cbit = (c&(1<<i))>0?1:0;

            //System.out.println(bit1 + " , "+ bit2 + " , " + cbit);

            int k = bit1|bit2;

            if(k == cbit){
                continue;
            }
            else if(cbit==0){
                
                ans += (bit1>0)?1:0;
                ans += (bit2>0)?1:0;
            }
            else{
                ans++;
            }
        }

        return ans;
    }
}
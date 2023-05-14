public class Solution {
    Dictionary<int,int> dp ;
    public int MaxScore(int[] nums) {
        int hs = 0;
        dp = new Dictionary<int,int>();
        return backtrack(nums,hs,1);
    }

    public int backtrack(int[] nums,int hs,int k){
        int ans = 0;
        int n = nums.Length;

        if(dp.ContainsKey(hs)){
            return dp[hs];
        }

        for(int i=0;i<n;i++){
            //check the ith bit
            if(checksetbit(hs,i)){
                continue;
            }
            for(int j=0;j<n;j++){
                if(i==j || checksetbit(hs,j)){
                    continue;
                }

                int x = gcd(nums[i],nums[j]);
                //Console.WriteLine($"{i},{j} -> {x}");
                int temp = k*x;

                //set ith bit 

                hs = setunsetBit(hs,i);
                hs = setunsetBit(hs,j);

                temp += backtrack(nums,hs,k+1);
                ans = Math.Max(ans,temp);

                hs = setunsetBit(hs,i);
                hs = setunsetBit(hs,j);
            }
        }

        dp[hs] = ans;

        return ans;
    }

    public int gcd(int x, int y){
        if(y==0){
            return x;
        }

        return gcd(y,x%y);
    }

    public bool checksetbit(int x, int i){
        if((x&(1<<i))>0 ){
            //Console.WriteLine($"{x},{i} -> true");
            return true;
        }
        //Console.WriteLine($"{x},{i} -> false");
        return false;
    }

    public int setunsetBit(int x, int i){    
        int k = (x^(1<<i));
        //Console.WriteLine($"{x},{i} -> {k}");
        return k;
    }

    
}
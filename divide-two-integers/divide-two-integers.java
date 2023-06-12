class Solution {
    public int divide(int dividend, int divisor) {
        if(divisor==Integer.MIN_VALUE){
            return dividend==Integer.MIN_VALUE?1:0;
        }

        long m = Math.abs((long)dividend);
        long n = Math.abs((long)divisor);

        boolean sign = true;

        if(dividend<0){
            sign = !sign;
        }

        if(divisor<0){
            sign = !sign;
        }

        long ans = 0;

        for(int i=31;i>=0;i--){
            //if ith bit is msb for current m when divided by n
            long k = n<<i;

            if(k<=m){
                //System.out.println(k);
                ans |= ((long)1<<i);
                m -= k;
            }
        }

        System.out.println(ans);

       ans = sign?ans:(-ans);

       if(ans>Integer.MAX_VALUE){
           return Integer.MAX_VALUE;
       }

       if(ans<Integer.MIN_VALUE){
           return Integer.MIN_VALUE;
       }

       //System.out.println(ans);

       return (int)ans;
    }
}
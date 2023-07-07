class Solution {
    public int maxConsecutiveAnswers(String answerKey, int k) {
        //TTFF 
        int len1 = getData(answerKey,k,'T');
        int len2 = getData(answerKey,k,'F');

        return Math.max(len1,len2);
    }

    public int getData(String answerKey,int k,char ch){

        System.out.println("For ::: "+ch);
        int n = answerKey.length();

        List<Integer> falses = new ArrayList<>();

        for(int i=0;i<n;i++){
            if(answerKey.charAt(i)==ch){
                falses.add(i);
            }
        }

        int m = falses.size();

        //sliding window on falses
        int s = -1;
        int e = Math.min(k,m);

        int len = (e<m)?falses.get(e)-s-1:n-s-1;

        System.out.println("exclude"+(s<0?s:falses.get(s))+",exclude"+(e>=m?n:falses.get(e)));

        s++;
        e++;

        while(e<m){
            int currLen = falses.get(e)-falses.get(s)-1;

            System.out.println("exclude"+falses.get(s)+",exclude"+falses.get(e));

            len = Math.max(len,currLen);

            s++;
            e++;
            
        }

        if(e==m){
            len = Math.max(n-falses.get(s)-1,len);
        }



        return len;
    }
}
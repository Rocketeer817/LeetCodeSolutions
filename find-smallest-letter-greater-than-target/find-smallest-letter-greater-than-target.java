class Solution {
    public char nextGreatestLetter(char[] letters, char target) {
        int l = 0;
        int r = letters.length-1;

        int ans = -1;

        while(l<=r){
            int mid = l + (r-l)/2;

            if(check(letters,target,mid)){
                ans = mid;
                r = mid-1;
            }
            else{
                l = mid+1;
            }
        }

        return ans>=0?letters[ans]:letters[0];
    }

    public boolean check(char[] letters, char target, int i){
        return (letters[i]-target) > 0 ;
    }
}
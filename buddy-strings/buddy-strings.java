class Solution {
    public boolean buddyStrings(String s, String goal) {
        int n = s.length();
        
        if(goal.length()!=n){
            return false;
        }

        int count = 0;
        int firstIndex = -1;

        Set<Character> set = new HashSet<Character>();

        boolean duplicateCase = false;
        boolean swappingPossible = false;

        for(int i=0;i<n;i++){
            char ch1 = s.charAt(i);
            char ch2 = goal.charAt(i);

            if(set.contains(ch1)){
                duplicateCase = true;
            }

            set.add(ch1);

            if(ch1==ch2){
                continue;
            }

            count++;

            if(count>2){
                return false;
            }
            else if(count==1){
                firstIndex = i;
            }
            else if(count==2){
                swappingPossible = check(s,goal,firstIndex,i);
            }
            
        }

        return (count>0)?swappingPossible : duplicateCase;
    }

    public boolean check(String curr, String target, int a, int b){
        if(curr.charAt(a)==target.charAt(b) && curr.charAt(b)==target.charAt(a)){
            return true;
        }
        return false;
    }
}
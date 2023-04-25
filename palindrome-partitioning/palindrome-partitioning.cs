public class Solution {
    public bool[,] pal;
    public IList<IList<string>> Partition(string s) {
        int n = s.Length;
        BuildPalindromeChecker(s);
        IList<IList<string>>[] dp = new List<IList<string>>[n];
        for(int i=0;i<n;i++){
            dp[i] = new List<IList<string>>();
        }

        //for i = 0 
        dp[0].Add(new List<string>{$"{s[0]}"});

        for(int i=1;i<n;i++){
            if(pal[0,i]==true){
                string sub = s.Substring(0,i+1);
                dp[i].Add(new List<string>{sub});
            }
            for(int j=0;j<i;j++){
                if(pal[j+1,i]==false){
                    continue;
                }
                string sub = s.Substring(j+1,i-j);
                foreach(IList<string> curr in dp[j]){
                    IList<string> temp = new List<string>();
                    foreach(string a in curr){
                        temp.Add(a);
                    }
                    temp.Add(sub);
                    dp[i].Add(temp);
                }
            }


        }

        return dp[n-1];
        
    }

    public void BuildPalindromeChecker(string s){
        int n = s.Length;
        pal = new bool[n,n];

        for(int r=n-1;r>=0;r--){
            for(int c = n-1;c>=r;c--){
                if(s[r]==s[c]){
                    if(r+1 <= c-1){
                        pal[r,c] = pal[r+1,c-1];
                    }
                    else{
                        pal[r,c] = true;
                    }
                }
                else{
                    pal[r,c] = false;
                }
            }
        }
    }

}
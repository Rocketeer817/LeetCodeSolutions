public class Solution {
    public bool[,] pal;
    public IList<IList<string>> Partition(string s) {
        int n = s.Length;
        BuildPalindromeChecker(s);
        
        IList<IList<string>> ans = new List<IList<string>>();
        IList<string> stack = new List<string>();

        dfs(s,0,stack,ans);

        return ans;
        
    }

    public void dfs(string s,int idx, IList<string> stack, IList<IList<string>> ans){
        int n = s.Length;
        if(idx==n){
            if(stack.Count>0){
                ans.Add(stack.ToList());
            }
            return;
        }

        for(int i=idx+1;i<n;i++){
            if(pal[idx,i-1]==true){
                stack.Add(s.Substring(idx,i-1-idx+1));
                dfs(s,i,stack,ans);
                stack.RemoveAt(stack.Count-1);
            }
        }

        if(pal[idx,n-1]==true){
            stack.Add(s.Substring(idx));
            dfs(s,n,stack,ans);
            stack.RemoveAt(stack.Count-1);
        }
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

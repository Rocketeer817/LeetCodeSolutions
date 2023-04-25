public class Solution {

    public TrieNode root;

    public IList<string> WordBreak(string s, IList<string> wordDict) {
        root = new TrieNode();

        foreach(string word in wordDict){
            Insert(word);
        }

        int n = s.Length;

        IList<string>[] dp = new List<string>[n];


        for(int i=n-1;i>=0;i--){
            IList<string> ans = new List<string>();
            for(int j=n-1;j>=i;j--){
                string sub = s.Substring(i,j-i+1);
                if(Search(sub)){
                    if(j==n-1){
                        ans.Add(sub);
                    }
                    else{
                        var temp = dp[j+1].ToList();
                        foreach(var curr in temp){
                            ans.Add($"{sub} {curr}");
                        }
                    }                                        
                }
            }
            dp[i] = ans;
        }

        return dp[0];
    }

    public void Insert(string word){
        TrieNode temp = root;
        
        for(int i=0;i<word.Length;i++){
            if(!temp.Map.ContainsKey(word[i])){
                temp.Map[word[i]] = new TrieNode();
            }
            temp = temp.Map[word[i]];
        }

        temp.End = true;
    }

    public bool Search(string word){
        TrieNode temp = root;

        for(int i=0;i<word.Length;i++){
            if(!temp.Map.ContainsKey(word[i])){
                return false;
            }
            temp = temp.Map[word[i]];
        }

        return temp.End?true:false;
    }

}

public class TrieNode{
    public bool End;
    public Dictionary<char,TrieNode> Map;

    public TrieNode(){
        End = false;
        Map = new Dictionary<char,TrieNode>();
    }
}
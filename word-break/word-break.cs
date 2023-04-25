public class Solution {
    public TrieNode root;
    public bool WordBreak(string s, IList<string> wordDict) {
        root = new TrieNode();

        foreach(string word in wordDict){
            Insert(word);
        }

        int n = s.Length;

        bool[] dp = new bool[n+1];

        dp[n] = true;

        for(int i=n-1;i>=0;i--){
            bool ans = false;
            for(int j=n-1;j>=i;j--){
                string sub = s.Substring(i,j-i+1);
                if(Search(sub)){
                    ans = ans || dp[j+1];
                    
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
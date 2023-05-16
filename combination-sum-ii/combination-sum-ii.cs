public class Solution {

    IList<IList<int>> ans;

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        ans = new List<IList<int>>();

        int n = candidates.Length;

        Dictionary<int,int> freq = new Dictionary<int,int>();
        
        for(int i=0;i<n;i++){
            if(!freq.ContainsKey(candidates[i])){
                freq[candidates[i]] = 1;
            }
            else{
                freq[candidates[i]]++;
            }
        }

        List<int> elements = freq.Keys.ToList();
        elements.Sort();
        
        IList<int> currList = new List<int>();

        BackTrack(elements,target,currList,freq,0,0);

        return ans;
    }

    
    public void BackTrack(List<int> elements,int target,IList<int> currList,Dictionary<int,int> freq,int index,int currSum){
        int n = elements.Count;
        if(currSum>target || index>=n){
            return;
        }

        if(currSum==target){
            IList<int> temp = new List<int>();
            foreach(int x in currList){
                temp.Add(x);
            }
            ans.Add(temp);
            return;
        }

        for(int i=index;i<n;i++){
            //consider elements[i]
            
            int elem = elements[i];

            if(freq[elem]<=0){
                continue;
            }

            //add elem 
            currSum += elem;
            currList.Add(elem);
            freq[elem]--;
            BackTrack(elements,target,currList,freq,i,currSum);

            //undo add elem;
            freq[elem]++;
            currSum -= elem;
            currList.RemoveAt(currList.Count-1);
            

            
        }
    }
}
public class Solution {
    IList<IList<int>> ans;
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        ans = new List<IList<int>>();
        
        IList<int> currList = new List<int>();

        BackTrack(candidates,target,currList,0,0);

        return ans;
    }

    public void BackTrack(int[] candidates,int target,IList<int> currList,int index,int currSum){
        int n = candidates.Length;
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
            //consider candidates[i]
            currSum += candidates[i];
            currList.Add(candidates[i]);

            BackTrack(candidates,target,currList,i,currSum);

            currSum -= candidates[i];
            currList.RemoveAt(currList.Count-1);
        }
    }
}
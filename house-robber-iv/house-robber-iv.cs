public class Solution {
    public int MinCapability(int[] nums, int k) {
        int n = nums.Length;

        int l = 0;
        int h = (int)Math.Pow(10,9);

        int ans = -1;

        while(l<=h){
            int mid = l + (h-l)/2;
            
            if(check(nums,mid,k)){
                ans = mid;
                h = mid-1;
            }
            else{
                l = mid+1;
            }
        }

        return ans;
    }

    public bool check(int[] nums,int mid,int k){
        int n = nums.Length;

        List<int> robPossible = new List<int>();

        for(int i=0;i<n;i++){
            if(nums[i]<=mid){
                robPossible.Add(i);
            }
        }

        int count = 0;

        //if no house possible to rob
        if(robPossible.Count==0){
            return count>=k;
        }

        //select the first house.
        int consecutive = 1;
        

        for(int i=1;i<robPossible.Count;i++){
            if(robPossible[i]-robPossible[i-1]==1){
                consecutive++;
            }
            else{
                count += (consecutive+1)/2;
                consecutive = 1;
            }
        }

        count += (consecutive+1)/2;

        //Console.WriteLine($"{mid}->{count}");

        return count>=k;
        
    }
}
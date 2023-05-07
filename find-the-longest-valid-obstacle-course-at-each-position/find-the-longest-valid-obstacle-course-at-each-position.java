public class Solution {
    public int[] longestObstacleCourseAtEachPosition(int[] obstacles) {
        int n = obstacles.length;
        List<Integer> list = new ArrayList<>();
        
        int[] ans = new int[n];
        list.add(obstacles[0]);
        ans[0] = 1;
        int size = 1;
        for(int i=1;i<n;i++){
            if(list.get(size-1)<=obstacles[i]){
                list.add(obstacles[i]);
                size++;
                ans[i] = size;
            }
            else{
                int index = binarySearch(list,obstacles[i]);
                list.set(index,obstacles[i]);
                ans[i] = index+1;
            }
        }

        return ans;

    }

    public int binarySearch(List<Integer> list, int k){
        int n = list.size();

        int l = 0;
        int h = n-1;

        int ans = -1;

        while(l<=h){
            int mid = (l+h)/2;
            if(list.get(mid)>k){
                ans = mid;
                h = mid-1;
            }
            else{
                l = mid+1;
            }
        }

        return ans;
    }
}
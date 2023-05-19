public class Solution {
    public int MaxAbsValExpr(int[] arr1, int[] arr2) {
        //Cases are : consider j>i
        // 1. arr1[j] > arr1[i], arr2[j]>arr2[i], j>i => arr1[j]+arr2[j]+j
        // 2. arr1[j] < arr1[i], arr2[j]>arr2[i], j>i => -arr1[j]+arr2[j]+j
        // 3. arr1[j] < arr1[i], arr2[j]<arr2[i], j>i => -arr1[j]-arr2[j]+j
        // 4. arr1[j] > arr1[i], arr2[j]<arr2[i], j>i => arr1[j]-arr2[j]+j

        return Math.Max(Math.Max(Case1(arr1,arr2),Case2(arr1,arr2)),Math.Max(Case3(arr1,arr2),Case4(arr1,arr2)));
    }

    public int Case1(int[] arr1,int[] arr2){
        int n = arr1.Length;

        int max = int.MinValue;
        int min = int.MaxValue;
        for(int i=0;i<n;i++){
            int elem = arr1[i]+arr2[i]+i;
            max = Math.Max(elem,max);
            min = Math.Min(elem,min);
        }

        //Console.WriteLine($"Case1 : {max},{min}");
        return max-min;
    }

    public int Case2(int[] arr1,int[] arr2){
        int n = arr1.Length;

        int max = int.MinValue;
        int min = int.MaxValue;
        for(int i=0;i<n;i++){
            int elem = -arr1[i]+arr2[i]+i;
            max = Math.Max(elem,max);
            min = Math.Min(elem,min);
        }

        return max-min;
    }

    public int Case3(int[] arr1,int[] arr2){
        int n = arr1.Length;

        int max = int.MinValue;
        int min = int.MaxValue;
        for(int i=0;i<n;i++){
            int elem = -arr1[i]-arr2[i]+i;
            max = Math.Max(elem,max);
            min = Math.Min(elem,min);
        }

        return max-min;
    }

    public int Case4(int[] arr1,int[] arr2){
        int n = arr1.Length;

        int max = int.MinValue;
        int min = int.MaxValue;
        for(int i=0;i<n;i++){
            int elem = arr1[i]-arr2[i]+i;
            max = Math.Max(elem,max);
            min = Math.Min(elem,min);
        }

        return max-min;
    }
}
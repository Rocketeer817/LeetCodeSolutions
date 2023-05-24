public class Solution {
    public int KthFactor(int n, int k) {
        List<int> factors = new List<int>();

        factors.Add(1);

        for(int i=2;i*i<=n;i++){
            if(n%i==0){
                factors.Add(i);
            }
        }

        if(factors.Count>=k){
            return factors[k-1];
        }

        Console.WriteLine("First half found");

        int a = factors.Count;
        for(int i=a-1;i>=0;i--){
            int x = n/factors[i];
            if(x!=factors[i]){
                factors.Add(x);
            }
        }

        return factors.Count<k?-1:factors[k-1];
    }
}
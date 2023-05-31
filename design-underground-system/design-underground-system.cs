public class UndergroundSystem {

    private Dictionary<string,Tuple<int,double>> avgTimes; 

    private Dictionary<int,Tuple<string,int>> checkIns;

    public UndergroundSystem() {
        avgTimes = new Dictionary<string,Tuple<int,double>>();
        checkIns = new Dictionary<int,Tuple<string,int>>();
    }
    
    public void CheckIn(int id, string stationName, int t) {
        checkIns[id] = new Tuple<string,int>(stationName,t);
    }
    
    public void CheckOut(int id, string stationName, int t) {
        Tuple<string,int> cIn = checkIns[id];

        string path = cIn.Item1+","+stationName;

        int timeTaken = t-cIn.Item2;

        if(avgTimes.ContainsKey(path)){
            Tuple<int,double> curr = avgTimes[path];
            double totalTime = curr.Item1 * curr.Item2;
            totalTime += timeTaken;
            
            double avg = (totalTime)/(curr.Item1+1);

            avgTimes[path] = new Tuple<int,double>(curr.Item1+1,avg);
        }
        else{
            avgTimes[path] = new Tuple<int,double>(1,timeTaken);
        }

        checkIns.Remove(id);
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        string path = startStation+","+endStation;
        return avgTimes[path].Item2;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */
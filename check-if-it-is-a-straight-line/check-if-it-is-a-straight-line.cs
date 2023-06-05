public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        //exception case : parallel to y - axis
        int sx = coordinates[0][0], sy = coordinates[0][1];

        if(coordinates[1][0]==sx){
            for(int i=2;i<coordinates.Length;i++){
                int cx = coordinates[i][0], cy = coordinates[i][1];
                if(cx!=sx){
                    return false;
                }
                
            }
        }
        else{
            double slope = (double)(coordinates[1][1]-sy)/(coordinates[1][0]-sx) ;
            
            for(int i=2;i<coordinates.Length;i++){
                int cx = coordinates[i][0], cy = coordinates[i][1];
                if(cx==sx){
                    return false;
                }

                double currSlope = ((double)(cy-sy))/((double)(cx-sx));

                if(currSlope!=slope){
                    return false;
                }
            }
        }

        return true;
    }
}
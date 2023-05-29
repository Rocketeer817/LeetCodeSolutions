public class ParkingSystem {

    private int bigCarCount ;
    private int mediumCarCount ;
    private int smallCarCount ;

    private int bigLimit;
    private int mediumLimit;
    private int smallLimit;

    public ParkingSystem(int big, int medium, int small) {
        bigLimit = big;
        mediumLimit = medium;
        smallLimit = small;

        bigCarCount = 0;
        mediumCarCount = 0;
        smallCarCount = 0;
    }
    
    public bool AddCar(int carType) {
        switch(carType){
            case 1:
                if(bigCarCount>=bigLimit){
                    return false;
                }
                bigCarCount++;
                break;
            case 2:
                if(mediumCarCount >= mediumLimit){
                    return false;
                }
                mediumCarCount++;
                break;
            case 3:
                if(smallCarCount >= smallLimit){
                    return false;
                }
                smallCarCount++;
                break;
            default:
                return false;
                break;
        }

        return true;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */
class Solution {
    public List<Integer> survivedRobotsHealths(int[] positions, int[] healths, String directions) {
        int n = positions.length;

        Robot[] arr = new Robot[n];

        for(int i=0;i<n;i++){
            arr[i] = new Robot(i,positions[i],healths[i],directions.charAt(i));
        }

        Arrays.sort(arr,(a,b)->a.position-b.position);

        
        Stack<Robot> stack = new Stack<Robot>();

        for(int i=0;i<n;i++){
            Robot next = arr[i];

            boolean noNext = false;

            while(stack.size()>0){
                Robot curr = stack.peek();
                if(curr.direction == 'R' && next.direction=='L'){
                    Robot temp = stack.pop();
                    if(temp.health>next.health){
                        //eliminate next
                        System.out.println("Eliminate "+next.position);
                        temp.health -= 1;
                        next = temp;
                    }
                    else if(temp.health < next.health){
                        //eliminate temp
                        System.out.println("Eliminate "+temp.position);
                        next.health -= 1;
                    }
                    else{
                        System.out.println("Eliminate "+temp.position+"\t" +next.position);
                        noNext = true;
                        break;
                    }
                }
                else{
                    break;
                }
            }

            if(noNext == false){
                stack.push(next);
            }
        }

        List<Robot> ans = new ArrayList<Robot>();
        for(Robot r : stack){
            ans.add(r);
        }

        ans.sort((a,b)->a.index-b.index);

        List<Integer> req = new ArrayList<Integer>();

        for(Robot r : ans){
            System.out.println(r.position + "\t" + r);
            req.add(r.health);
        }

        return req;
    }
}

class Robot{
    public int index;
    public int position;
    public int health;
    public char direction;

    public Robot(int idx,int p, int h, char direction){
        this.index = idx;
        this.position = p;
        this.health = h;
        this.direction = direction;
    }

}
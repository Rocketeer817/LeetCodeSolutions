public class Solution {
    public bool IsValidSudoku(char[][] board) {
        //row wise validation
        for(int r=0;r<9;r++){
            if(RowWiseValidation(board,r)==false){
                return false;
            }
        }

        //col wise validation
        for(int c=0;c<9;c++){
            if(ColumnWiseValidation(board,c)==false){
                return false;
            }
        }

        //grid wise validation
        for(int g=0;g<9;g++){
            if(GridWiseValidation(board,g)==false){
                return false;
            }
        }

        return true;
    }

    public bool RowWiseValidation(char[][] board, int r){
        HashSet<int> hs = new HashSet<int>();
        for(int col=0;col<9;col++){
            if(board[r][col]=='.'){
                continue;
            }
            int k = board[r][col]-'0';
            if(hs.Contains(k)){
                return false;
            }
            hs.Add(k);
        }

        return true;
    }

    public bool ColumnWiseValidation(char[][] board, int col){
        HashSet<int> hs = new HashSet<int>();
        for(int row=0;row<9;row++){
            if(board[row][col]=='.'){
                continue;
            }
            int k = board[row][col]-'0';
            if(hs.Contains(k)){
                return false;
            }
            hs.Add(k);
        }

        return true;
    }

    public bool GridWiseValidation(char[][] board, int grid){
        HashSet<int> hs = new HashSet<int>();
        int rowOffset = (grid/3)*3;
        int colOffset = (grid%3)*3;
        for(int r=0;r<3;r++){
            for(int c=0;c<3;c++){
                int row = rowOffset+r;
                int col = colOffset+c;
                
                if(board[row][col]=='.'){
                    continue;
                }
                int k = board[row][col]-'0';
                if(hs.Contains(k)){
                    return false;
                }
                hs.Add(k);
            }
        }

        return true;
    }
}
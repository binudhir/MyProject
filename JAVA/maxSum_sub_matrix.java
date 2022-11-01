import java.util.ArrayList;

//Maximum Sum Submatrix
//Given a N * M 2D matrix A. Find the maximum sum sub-matrix from the matrix A. Return the Sum.
//import java.lang.*;
public class maxSum_sub_matrix{
 public static int kadane(ArrayList<Integer> v)
    {
        int currSum = 0;
        int max_Sum = Integer.MIN_VALUE;
        for (int i = 0; i < (int)v.size(); i++) {
            currSum += v.get(i);
            if (currSum > max_Sum) {
                max_Sum = currSum;
            }
     
            if (currSum < 0) {
                currSum = 0;
            }
        }
        return max_Sum;
    }
    public static int solve(int[][] A) {
        int r = A.length;
        int c = A[0].length;
        int prefix[][] = new int[r][c];
        for(int i=0 ; i<r ; i++){
            for(int j=0 ; j<c ; j++){
                if(j==0)
                    prefix[i][j] = A[i][j];
                else
                    prefix[i][j] = A[i][j] + prefix[i][j - 1];
            }
        }
        int maxSum = Integer.MIN_VALUE;
        for (int i = 0; i < c; i++) {
            for (int j = i; j < c; j++) {
                ArrayList<Integer> v = new ArrayList<>(); 
                for (int k = 0; k < r; k++) {
                    int el = 0;
                    if (i == 0)
                        el = prefix[k][j];
                    else
                        el = prefix[k][j] - prefix[k][i - 1];
                    v.add(el);
                }
                maxSum = Math.max(maxSum, kadane(v));
            }
        }
        return maxSum;
    }

public static void main(String[] args){
int ar[][]={{1, 2, 3, 9}, {4, 5, 6, 2},{8, 3, 2, 6}};
//int max_sum=solve(ar[][])
    //System.out.println("Max Sum is " + max_sum);
}
}

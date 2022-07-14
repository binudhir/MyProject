//Give a N * N square matrix A, return an array of its anti-diagonals.
import java.util.*;
public class diagonals{
// Function to print diagonals
static void diagonal(int[][] A){
int n=A.length;
int N=2*n-1;
ArrayList<ArrayList<Integer>> result=new ArrayList<ArrayList<Integer>>();
for(int i = 0; i < N; i++){
        result.add(new ArrayList<>());
}
    // Push each element in the result vector
    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            result.get(i + j).add(A[i][j]);
        }
    }
    // Print the diagonals
    for(int i = 0; i < result.size(); i++)
    {
        System.out.println();
        for(int j = 0; j < result.get(i).size(); j++){
            System.out.print(result.get(i).get(j) + " ");
        }
    System.out.print(0);
    }


}
public static void main(String[] args){
    int[][] A = { { 1, 2, 3, 4 },
                  { 5, 6, 7, 8 },
                  { 9, 10, 11, 12 },
                  { 13, 14, 15, 16 } };
      
    // Function Call
    diagonal(A);
}
}

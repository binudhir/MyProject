//import java.util.*;
public class antidiagonal{
static int[][] result(int[][] A) {
        int[][] res = new int[2*A.length-1][A.length];
         int k = 0;
         for(int i=0;i<A.length;i++){

             int p = 0,q = i,m=0;
             while(p<A.length && q>=0){
                 
                 res[k][m++] = A[p][q];
                 p++;
                 q--;
             }
             if(p != A.length){
                 int l=m;
                 while(p<A.length && l<A[i].length){
                     res[k][l] = 0;
                     p++;l++;
                 }
             }   
             k++;
         }
         int j=A.length-1;
         for(int i=1;i<A.length;i++){
             
             int q = j,m=0,t=i;
             while(t<A.length && q>=0){
                 res[k][m++] = A[t][q];
                 t++;
                 q--;
             }
             if(t!=A.length-1){
                 while(t<A.length && m<A[j].length){
                     res[k][m] = 0;
                     t++;m++;
                 }
             }
             k++;
         }         
         return res;
    }
public static void main(String[] args){
 int[][] a = { { 1, 2, 3, 4 },
               { 5, 6, 7, 8 },
               { 9, 10, 11, 12 },
               { 13, 14, 15, 16 } };
System.out.println(result(a));
}
}

//Program to Substract two matrices
//import java.util.*;
public class matrixsubstact{
public static void main(String[] args){
int a[][]={{9,8,7},{6,5,4},{3,2,1}};
int b[][]={{1,2,3},{4,5,6},{7,8,9}};
int rw=a.length;
int cl=a[0].length;
int[][] c=new int[rw][cl];
for(int i=0; i<rw; i++){
    for(int j=0; j<cl; j++){
        c[i][j]=a[i][j]-b[i][j];
        System.out.print(c[i][j]+" ");
    }
System.out.println();
}
}
}

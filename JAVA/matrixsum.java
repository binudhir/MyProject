//Program to add two matrices
//import java.util.*;
public class matrixsum{
public static void main(String[] args){
int a[][]={{1,2,3},{4,5,6},{7,8,9}};
int b[][]={{9,8,7},{6,5,4},{3,2,1}};
int rw=a.length;
int cl=a[0].length;
int c[][]=new int[rw][cl];//Create new Matrix for 3 rows and 3 columns  
for(int i=0; i<rw; i++){
    for(int j=0; j<cl; j++){
        c[i][j]=a[i][j]+b[i][j];
        System.out.print(c[i][j]+" ");
    }
System.out.println();
}

}
}

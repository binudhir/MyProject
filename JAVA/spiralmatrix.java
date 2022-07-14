import java.util.*;
public class spiralmatrix{
public static void main(String[] args){
    System.out.println("Enter the Size :");
    Scanner sc=new Scanner(System.in);
    int A=sc.nextInt();
    int j=0,cnt=1,left=0,top=A-1;
    int mat[][]=new int[A][A];
    for(int i=0; i<A; i++, left++, top--){  //Over all Loop
        for(j=left; j<=top; j++){           //fill from left to right  
            mat[left][j]=cnt++;
        }
        for(j=left+1; j<=top; j++){         //fill from Top to Bottom 
            mat[j][top]=cnt++;
        }
        for(j=top-1; j>=left; j--){         //fill from Right to left 
            mat[top][j]=cnt++;
        }
        for(j=top-1; j>=left+1; j--){       //fill from Bottom to Top 
            mat[j][left]=cnt++;
        }
    }
    for(int i=0; i<A; i++){                 //fill Printing Loop
        for(j=0; j<A; j++){
            System.out.printf("%-5d",mat[i][j]);    //Display the Matrix
        }
        System.out.printf("\n");
    }
    sc.close();
}
}

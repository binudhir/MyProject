import java.util.*;
//import java.lang.*;
public class numberpyramid{
public static void main(String[] args){
    System.out.println("Enter the Row Number :");
    Scanner sc = new Scanner(System.in);
    int rw = sc.nextInt();
    for (int i=rw; i>=1; i--) {
        for (int j=1; j<=i; j++){
        if (j<i)
        System.out.print(j + " ");
        else
        System.out.print(j);
        }
    System.out.println();    
    }
    sc.close();
}
}

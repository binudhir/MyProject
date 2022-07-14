//Print the Star Pattern
//import java.lang.*;
import java.util.*;
public class starpettern{
public static void main(String[] args){
    System.out.println("Enter a Number:");
    Scanner sc = new Scanner(System.in);
    int n = sc.nextInt();
    for (int i=0; i<n; i++) {
    for (int j=0; j<=i; j++){
        System.out.print("*");        
        }    
        System.out.println();
    }
    sc.close();
    }
}


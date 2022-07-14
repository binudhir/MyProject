//Print the Letter Pattern
//import java.lang.*;
import java.util.*;
public class letterpettern{
public static void main(String[] args){
    int l = 65; //ASCII Value of A is 65
    System.out.println("Enter the Number: ");
    Scanner sc = new Scanner(System.in); 
    int n = sc.nextInt();
    for (int i=0; i<n; i++){
        for (int j=0; j<=i; j++){
        // Print the Charcter
        if (j<i)
        System.out.print((char) l + " ");
        else
         System.out.print((char) l);
        }
    l++;
    System.out.println();    
    }
    sc.close(); 
 }
}
